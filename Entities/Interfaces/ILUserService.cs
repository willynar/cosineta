using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

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
        Task<List<ApplicationRole>> GetAllRoles();
        Task<List<Link>> GetAllLinks();
        Task<List<RolLink>> GetAllRolLinks();
        Task<List<Module>> GetAllModules();
        Task<List<UserRole>> GetAllUsersRoles();

        #region Reviews

        /// <summary>
        /// call actions necesary to save new review User
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task ActionsAddUserReview(Review review);

        /// <summary>
        /// call actions necesary to update review User
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task ActionsUpdUserReview(Review review);

        /// <summary>
        /// list revies stars
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<List<int>> ListReviewStarsUserId(Review review);

        /// <summary>
        /// update stars averrange fro User
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <param name="averageStars"></param>
        /// <returns></returns>
        Task UpdStarsUser(string? applicationUserId, decimal averageStars, int quantityReview);

        Task<List<Review>> GetAllUserReviews();

        /// <summary>
        /// get Review by id Review
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns></returns>
        Task<Review> GetUserReviewByUserId(string? applicationUserId);

        /// <summary>
        /// save new Review
        /// </summary>
        /// <param name="review"></param>
        Task AddUserReview(Review review);

        /// <summary>
        /// update Review by id
        /// </summary>
        /// <param name="updatedReview"></param>
        Task UpdUserReviewById(Review updatedReview);

        /// <summary>
        /// delete Review by id Review
        /// </summary>
        /// <param name="reviewId"></param>
        Task DeleteUserReviewById(int reviewId);
        #endregion
    }
}
