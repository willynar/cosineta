using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security;
using System;
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
            return await _context.Users
                   .Where(user => user.Id == id)
                   .Include(user => user.UsersRoles)
                       .ThenInclude(userRole => userRole.ApplicationRoleIdNavigation)
                           .ThenInclude(role => role.RolLinks)
                               .ThenInclude(rolLink => rolLink.LinkIdNavigation)
                                   .ThenInclude(link => link.ModuleIdNavigation) // Include para Module en Link
                                                                                 // Agrega Include para otras propiedades de navegación según sea necesario
                   .FirstOrDefaultAsync();
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            var result = await _context.Users
                     .Include(user => user.UsersRoles)
                         .ThenInclude(userRole => userRole.ApplicationRoleIdNavigation)
                             .ThenInclude(role => role.RolLinks)
                         .ThenInclude(rolLink => rolLink.LinkIdNavigation)
                             .ThenInclude(link => link.ModuleIdNavigation)
                     .ToListAsync();
            return result;
        }

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

        public async Task Edit(ApplicationUser entity)
        {
            if (_context.Users.Any(x => x.Id == entity.Id))
            {
                var usuarioUpd = await _context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);
                usuarioUpd.UserName = entity.UserName;
                usuarioUpd.NormalizedUserName = entity.NormalizedUserName;
                usuarioUpd.Email = entity.Email;
                usuarioUpd.NormalizedEmail = entity.NormalizedEmail;
                usuarioUpd.EmailConfirmed = entity.EmailConfirmed;
                usuarioUpd.PasswordHash = entity.PasswordHash;
                usuarioUpd.SecurityStamp = entity.SecurityStamp;
                usuarioUpd.ConcurrencyStamp = entity.ConcurrencyStamp;
                usuarioUpd.PhoneNumber = entity.PhoneNumber;
                usuarioUpd.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
                usuarioUpd.TwoFactorEnabled = entity.TwoFactorEnabled;
                usuarioUpd.LockoutEnd = entity.LockoutEnd;
                usuarioUpd.LockoutEnabled = entity.LockoutEnabled;
                usuarioUpd.AccessFailedCount = entity.AccessFailedCount;
                usuarioUpd.Name = entity.Name;
                usuarioUpd.Active = entity.Active;
                _context.Entry(usuarioUpd).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IdentityResult> Save(ApplicationUser entity)
        {
            entity.TwoFactorEnabled = false;
            entity.LockoutEnabled = false;
            var result = await _userManager.CreateAsync(entity, entity.Password);


            _userManager.Dispose();
            return result;
        }

        public async Task<IdentityResult> SaveRole(ApplicationRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            return await _roleManager.CreateAsync(role);
        }

        public async Task<List<ApplicationRole>> GetAllRole() =>
           await _context.Roles.ToListAsync();

        public async Task AssignRoleAsync(ApplicationUser appUser)
        {
            try
            {
                if (_context.Users.Any(x => x.Id == appUser.Id))
                {
                    // Elimina roles no deseados
                    if (_context.UsersRoles.Any(x => x.ApplicationUserId == appUser.Id))
                    {
                        _context.UsersRoles.RemoveRange(_context.UsersRoles.Where(x => x.ApplicationUserId == appUser.Id));
                        await _context.SaveChangesAsync();
                    }

                    // Agrega roles nuevos
                    if (appUser.UsersRoles.Any())
                        foreach (var item in appUser.UsersRoles)
                        {
                            _context.UsersRoles.Add(item);
                            await _context.SaveChangesAsync();
                        }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
