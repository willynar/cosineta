using Microsoft.AspNetCore.Identity;

namespace Logic.Administration
{
    public class LUser : ILUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LUser(UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser?> GetById(string id) =>
           await _userManager.FindByIdAsync(id);

        public async Task<List<ApplicationUser>> GetAll() =>
           await _userManager.Users.Where(x => x.Active).ToListAsync();

        public async Task<ApplicationUser?> GetByEmail(string email) =>
            await _userManager.FindByEmailAsync(email);

        public async Task<ApplicationUser?> GetByUser(string user) =>
            await _userManager.FindByNameAsync(user);

        public async Task<ApplicationUser?> GetUserByUserOrEmail(string email) =>
            email.Contains('@') ? await _userManager.FindByEmailAsync(email) : await _userManager.FindByNameAsync(email);

        public async Task<IdentityResult> ChangePassword(ApplicationUser entity, ChangePasswordViewModel model) =>
            await _userManager.ChangePasswordAsync(entity, model.LastPassword, model.Password);

        public async Task<string> GenerateToken(ApplicationUser entity) =>
            await _userManager.GeneratePasswordResetTokenAsync(entity);

        public async Task<IdentityResult> ForceChangePassword(ApplicationUser entity, string token, string password) =>
            await _userManager.ResetPasswordAsync(entity, token, password);

        public async Task<SignInResult> ValidPassLogin(ApplicationUser entity) =>
            await _signInManager.PasswordSignInAsync(entity, entity.Password, isPersistent: false, lockoutOnFailure: false);

        public async Task<IdentityResult> Edit(ApplicationUser entity)
        {
            var result = await _userManager.UpdateAsync(entity);
            _userManager.Dispose();
            return result;
        }

        public async Task<IdentityResult> Save(ApplicationUser entity)
        {
            var result = await _userManager.CreateAsync(entity, entity.Password);
            _userManager.Dispose();
            return result;
        }
    }
}
