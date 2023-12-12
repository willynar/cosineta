using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Logic.Administration
{
    public class LUser : ILUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public LUser(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser?> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

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

        public async Task<IdentityResult> SaveRole(ApplicationRole role) =>
            await _roleManager.CreateAsync(role);

        public async Task AssignRoleAsync(ApplicationUser appUser, List<ApplicationRole> lstRole)
        {
            try
            {
                var userRoles = await _userManager.GetRolesAsync(appUser);
                var rolesToRemove = userRoles.Except(lstRole.Select(r => r.NormalizedName)).ToList();
                var rolesToAdd = lstRole.Select(r => r.NormalizedName).Except(userRoles).ToList();

                // Elimina roles no deseados
                if (rolesToRemove.Any())
                    await _userManager.RemoveFromRolesAsync(appUser, rolesToRemove);

                // Agrega roles nuevos
                if (rolesToAdd.Any())
                    await _userManager.AddToRolesAsync(appUser, rolesToAdd);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
