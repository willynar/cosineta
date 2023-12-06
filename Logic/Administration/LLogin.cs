using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logic.Administration
{
    public class LLogin : ILLoginService
    {
        private readonly IConfiguration _configuration;
        private readonly ILUserService _lUser;
        private readonly ILUserTokenService _lUserToken;

        public LLogin(IConfiguration configuration, ILUserService lUser, ILUserTokenService lUserToken)
        {
            _configuration = configuration;
            _lUser = lUser;
            _lUserToken = lUserToken;
        }

        public async Task<TokenViewModel> BuildToken(ApplicationUser entity)
        {
            var user = await _lUser.GetUserByUserOrEmail(entity.Login);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, entity.Login),
                    new Claim(ClaimTypes.NameIdentifier, entity.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                ClaimsIdentity claimsIdentity = new(claims, "Token");

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetConnectionString("Secret_key")?.ToString() ?? string.Empty));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new(issuer: _configuration.GetConnectionString("serverDomain"), audience: _configuration.GetConnectionString("serverDomain"),
                   claims: claimsIdentity.Claims, signingCredentials: creds);

                var resultUserToken = await _lUserToken.GetById(user.Id);
                if (resultUserToken != null)
                {
                    await _lUserToken.Delete(resultUserToken);
                }

                var userToken = new UserToken { UserId = user.Id, Token = new JwtSecurityTokenHandler().WriteToken(token) };
                await _lUserToken.Save(userToken);

                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user?.UserName ?? string.Empty,
                    Name = user?.Name ?? string.Empty,
                    Email = user?.Email ?? string.Empty,
                    //Rol = user?.Rol ?? string.Empty
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
            var res = await _lUserToken.GetById(userId);
            if (res != null)
            {
                await _lUserToken.Delete(res);
            }
        }
    }
}
