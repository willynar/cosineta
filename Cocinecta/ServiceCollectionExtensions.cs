using Entities.Administration;
using Logic.Dao;
using Microsoft.AspNetCore.Identity;

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
            services.AddScoped<IDaoService, LDao>();
            services.AddScoped<IExecuteProceduresService, LExecuteProcedures>();
            services.AddScoped<IStoredProceduresService, LStoreProcedures>();

            return services;
        }
    }
}
