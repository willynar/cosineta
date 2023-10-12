using Entities.Administration;
using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Entities.Interfaces
{
    public interface ILUser
    {
        Task<IdentityResult> ChangePassword(ApplicationUser entity, ChangePasswordViewModel model);
        Task<IdentityResult> Edit(ApplicationUser entity);
        Task<IdentityResult> ForceChangePassword(ApplicationUser entity, string token, string password);
        Task<string> GenerateToken(ApplicationUser entity);
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser?> GetByEmail(string email);
        Task<ApplicationUser?> GetById(string id);
        Task<ApplicationUser?> GetByUser(string user);
        Task<ApplicationUser?> GetUserByUserOrEmail(string email);
        Task<IdentityResult> Save(ApplicationUser entity);
        Task<SignInResult> ValidPassLogin(ApplicationUser entity);
    }
}
