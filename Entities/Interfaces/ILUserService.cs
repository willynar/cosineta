using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Entities.Interfaces
{
    public interface ILUserService
    {
        Task<IdentityResult> ChangePassword(ApplicationUser entity, ChangePasswordViewModel model);
        Task Edit(ApplicationUser entity);
        Task<IdentityResult> ForceChangePassword(ApplicationUser entity, string token, string password);
        Task<string> GenerateToken(ApplicationUser entity);
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser?> GetByEmail(string email);
        Task<ApplicationUser?> GetById(string id);
        Task<ApplicationUser?> GetByUser(string user);
        Task<ApplicationUser?> GetUserByUserOrEmail(string email);
        Task<IdentityResult> Save(ApplicationUser entity);
        Task<SignInResult> ValidPassLogin(ApplicationUser entity);
        Task<IdentityResult> SaveRole(ApplicationRole role);
        Task<List<ApplicationRole>> GetAllRole();
        Task AssignRoleAsync(string idUser, List<UserRole> ListaRoles);
        Task<List<RolLink>> GetModulesByUserId(string userId);
        Task<List<ApplicationRole>> GetRolsByUserId(string userId);
        Task SaveModule(Module module);
        Task SaveUserRole(UserRole userRole);
        Task SaveRolLink(RolLink rolLink);
        Task SaveLink(Link link);
        Task SaveApplicationRole(ApplicationRole role);
    }
}
