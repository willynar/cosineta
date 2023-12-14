using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logic.Administration
{
    public class LLogin : ILLoginService
    {
        private readonly IConfiguration IConfiguration;
        private readonly ILUserService ILUserService;
        private readonly ILUserTokenService ILUserTokenService;

        public LLogin(IConfiguration configuration, ILUserService lUser, ILUserTokenService lUserToken)
        {
            IConfiguration = configuration;
            ILUserService = lUser;
            ILUserTokenService = lUserToken;
        }

        public async Task<TokenViewModel> BuildToken(ApplicationUser entity)
        {
            var user = await ILUserService.GetUserByUserOrEmail(entity.Login);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, entity.Login),
                    new Claim(ClaimTypes.NameIdentifier, entity.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                ClaimsIdentity claimsIdentity = new(claims, "Token");

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IConfiguration.GetConnectionString("Secret_key")?.ToString() ?? string.Empty));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new(issuer: IConfiguration.GetConnectionString("serverDomain"), audience: IConfiguration.GetConnectionString("serverDomain"),
                   claims: claimsIdentity.Claims, signingCredentials: creds);

                var resultUserToken = await ILUserTokenService.GetById(user.Id);
                if (resultUserToken != null)
                {
                    await ILUserTokenService.Delete(resultUserToken);
                }

                var userToken = new UserToken { UserId = user.Id, Token = new JwtSecurityTokenHandler().WriteToken(token) };
                await ILUserTokenService.Save(userToken);

                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user?.UserName ?? string.Empty,
                    Name = user?.Name ?? string.Empty,
                    Email = user?.Email ?? string.Empty,
                    Rols = string.IsNullOrEmpty(user.Id) ? new() : await ILUserService.GetRolsByUserId(user.Id),
                    Modules = string.IsNullOrEmpty(user.Id) ? new() : await ILUserService.GetModulesByUserId(user.Id)
                };

                return new TokenViewModel
                {
                    Success = true,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    User = userViewModel
                };
            }
            else
            {
                throw new Exception(LErrors.TranslateError(ErrorType.UserNotFound));
            }
        }

        public async Task CloseSesion(string userId)
        {
            var res = await ILUserTokenService.GetById(userId);
            if (res != null)
            {
                await ILUserTokenService.Delete(res);
            }
        }
    }
}
