﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security;
using System;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Entities.Administration;
using System.Data;
using Entities.App;

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
                                   .ThenInclude(link => link.ModuleIdNavigation) 
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

        public async Task AssignRoleAsync(string idUser, List<UserRole> ListaRoles)
        {
            try
            {
                if (_context.Users.Any(x => x.Id == idUser))
                {
                    // Elimina roles no deseados
                    if (_context.UsersRoles.Any(x => x.ApplicationUserId == idUser))
                    {
                        _context.UsersRoles.RemoveRange(_context.UsersRoles.Where(x => x.ApplicationUserId == idUser));
                        await _context.SaveChangesAsync();
                    }

                    // Agrega roles nuevos
                    if (ListaRoles.Any())
                        foreach (var item in ListaRoles)
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

        public async Task<List<RolLink>> GetModulesByUserId(string userId) =>
            _context.Users
                .Where(user => user.Id == userId)
                .SelectMany(user => user.UsersRoles
                    .SelectMany(userRole => userRole.ApplicationRoleIdNavigation.RolLinks))
                .Include(rolLink => rolLink.LinkIdNavigation)
                .ToList();

        public async Task<List<ApplicationRole>> GetRolsByUserId(string userId) =>
           await _context.Users
        .Where(user => user.Id == userId)
        .SelectMany(user => user.UsersRoles
            .Select(userRole => userRole.ApplicationRoleIdNavigation))
        .ToListAsync();

        public async Task SaveModule(Module module)
        {
            // Lógica para guardar o actualizar un módulo
            if (module.ModuleId == 0)
            {
                // Agregar nuevo módulo
                _context.Modules.Add(module);
            }
            else
            {
                // Actualizar módulo existente
                _context.Entry(module).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveUserRole(UserRole userRole)
        {
            // Lógica para guardar o actualizar un UserRole
            if (userRole.UserRoleId == 0)
            {
                // Agregar nuevo UserRole
                _context.UsersRoles.Add(userRole);
            }
            else
            {
                // Actualizar UserRole existente
                _context.Entry(userRole).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveRolLink(RolLink rolLink)
        {
            // Lógica para guardar o actualizar un RolLink
            if (rolLink.RolLinkId == 0)
            {
                // Agregar nuevo RolLink
                _context.RolLinks.Add(rolLink);
            }
            else
            {
                // Actualizar RolLink existente
                _context.Entry(rolLink).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveLink(Link link)
        {
            // Lógica para guardar o actualizar un Link
            if (link.LinkId == 0)
            {
                // Agregar nuevo Link
                _context.Links.Add(link);
            }
            else
            {
                // Actualizar Link existente
                _context.Entry(link).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveApplicationRole(ApplicationRole role)
        {
            // Lógica para guardar o actualizar un ApplicationRole
            if (role.Id == null)
            {
                // Agregar nuevo ApplicationRole
                _context.Roles.Add(role);
            }
            else
            {
                // Actualizar ApplicationRole existente
                _context.Entry(role).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ApplicationRole>> GetAllRoles()
        {
            return await _context.Roles
                .Include(role => role.RolLinks)
                    .ThenInclude(rolLink => rolLink.LinkIdNavigation)
                        .ThenInclude(link => link.ModuleIdNavigation)
                .Include(role => role.UsersRoles)
                    .ThenInclude(userRole => userRole.ApplicationUserIdNavigation)
                        .ThenInclude(user => user.UsersRoles)
                .ToListAsync();
        }

        public async Task<List<Link>> GetAllLinks()
        {
            return await _context.Links
                .Include(link => link.ModuleIdNavigation)
                .Include(link => link.RolLinks)
                    .ThenInclude(rolLink => rolLink.ApplicationRoleIdNavigation)
                .ToListAsync();
        }

        public async Task<List<RolLink>> GetAllRolLinks()
        {
            return await _context.RolLinks
                .Include(rolLink => rolLink.ApplicationRoleIdNavigation)
                .Include(rolLink => rolLink.LinkIdNavigation)
                    .ThenInclude(link => link.ModuleIdNavigation)
                .ToListAsync();
        }

        public async Task<List<Module>> GetAllModules()
        {
            return await _context.Modules
                .Include(module => module.Links)
                    .ThenInclude(link => link.RolLinks)
                        .ThenInclude(rolLink => rolLink.ApplicationRoleIdNavigation)
                .ToListAsync();
        }

        public async Task<List<UserRole>> GetAllUsersRoles()
        {
            return await _context.UsersRoles
                .Include(userRole => userRole.ApplicationRoleIdNavigation)
                    .ThenInclude(role => role.RolLinks)
                        .ThenInclude(rolLink => rolLink.LinkIdNavigation)
                            .ThenInclude(link => link.ModuleIdNavigation)
                .Include(userRole => userRole.ApplicationUserIdNavigation)
                .ToListAsync();
        }

    }
}
