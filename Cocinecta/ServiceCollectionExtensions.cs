using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Entities.Administration;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Cocinecta
{
    static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register necessary services on the DI Container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> is used to
        /// generate an extension method</param>
        /// <returns>
        /// Returns a IServiceCollection that can be use on the ConfigureServices.
        /// </returns>
        public static IServiceCollection AddNecessaryServices(this IServiceCollection services)
        {
            services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            services.AddScoped<ILUserService, LUser>();
            services.AddScoped<ILUserTokenService, LUserToken>();
            services.AddScoped<ILLoginService, LLogin>();
            services.AddScoped<ICategoryService, LCategory>();
            services.AddScoped<IChefService, LChefs>();
            services.AddScoped<IProductService, LProduct>();

            return services;
        }
    }
}
