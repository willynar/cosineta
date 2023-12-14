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
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            //var users = await _context.Users
            //.Where(x => x.Active)
            //.ToListAsync();
            //var result = (from USU in users
            //              select new ApplicationUser()
            //              {
            //                  Id = USU.Id,
            //                  UserName = USU.UserName,
            //                  NormalizedUserName = USU.NormalizedUserName,
            //                  Email = USU.Email,
            //                  NormalizedEmail = USU.NormalizedEmail,
            //                  EmailConfirmed = USU.EmailConfirmed,
            //                  PasswordHash = USU.PasswordHash,
            //                  SecurityStamp = USU.SecurityStamp,
            //                  ConcurrencyStamp = USU.ConcurrencyStamp,
            //                  PhoneNumber = USU.PhoneNumber,
            //                  PhoneNumberConfirmed = USU.PhoneNumberConfirmed,
            //                  TwoFactorEnabled = USU.TwoFactorEnabled,
            //                  LockoutEnd = USU.LockoutEnd,
            //                  LockoutEnabled = USU.LockoutEnabled,
            //                  AccessFailedCount = USU.AccessFailedCount,
            //                  Name = USU.Name,
            //                  Active = USU.Active,
            //                  //Login = USU.Login,
            //                  Roles = _context.Roles.Include(x=>x.RolLinks).ToList()
            //                            .Join(_context.UserRoles, ar => ar.Id, aur => aur.RoleId, (ur, r) => ur).ToList()
            //              }).ToList();
            var userWithRelatedEntities = _context.Users
           .Include(user => user.Rols)
            .ThenInclude(userRole => userRole.RoleId)
                .ThenInclude(role => role.rol)
                    .ThenInclude(rolLink => rolLink.ApplicationRoleIdNavigation)
            .ThenInclude(userRole => userRole.Role)
                .ThenInclude(role => role.RolLinks)
                    .ThenInclude(rolLink => rolLink.LinkIdNavigation)
                        .ThenInclude(link => link.ModuleIdNavigation) // Include para Module en Link
                                                                      // Agrega Include para otras propiedades de navegación según sea necesario
        .ToList();

            return userWithRelatedEntities;
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
                var usuario = await _context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);
                usuario.UserName = entity.UserName;
                usuario.NormalizedUserName = entity.NormalizedUserName;
                usuario.Email = entity.Email;
                usuario.NormalizedEmail = entity.NormalizedEmail;
                usuario.EmailConfirmed = entity.EmailConfirmed;
                usuario.PasswordHash = entity.PasswordHash;
                usuario.SecurityStamp = entity.SecurityStamp;
                usuario.ConcurrencyStamp = entity.ConcurrencyStamp;
                usuario.PhoneNumber = entity.PhoneNumber;
                usuario.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
                usuario.TwoFactorEnabled = entity.TwoFactorEnabled;
                usuario.LockoutEnd = entity.LockoutEnd;
                usuario.LockoutEnabled = entity.LockoutEnabled;
                usuario.AccessFailedCount = entity.AccessFailedCount;
                usuario.Name = entity.Name;
                usuario.Active = entity.Active;
                _context.Entry(usuario).State = EntityState.Modified;
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
                    if (_context.UserRoles.Any(x => x.UserId == appUser.Id))
                    {
                        _context.UserRoles.RemoveRange(_context.UserRoles.Where(x => x.UserId == appUser.Id));
                        await _context.SaveChangesAsync();
                    }

                    // Agrega roles nuevos
                    if (appUser.Roles.Any())
                        foreach (var item in appUser.Roles)
                        {
                            _context.UserRoles.Add(new ApplicationUserRole() { RoleId = item.Id, UserId = appUser.Id });
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
