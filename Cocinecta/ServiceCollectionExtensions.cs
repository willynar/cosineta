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
            services.AddScoped<ILLoginService, LLogin>();
            services.AddScoped<ILUserTokenService, LUserToken>();
            services.AddScoped<ILUserService, LUser>();
            services.AddScoped<ICategoryService, LCategory>();
            services.AddScoped<IChefService, LChefs>();
            services.AddScoped<IProductService, LProduct>();

            return services;
        }
    }
}
