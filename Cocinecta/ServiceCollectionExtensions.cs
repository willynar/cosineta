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
            services.AddScoped<ILLogin, LLogin>();
            services.AddScoped<ILUserToken, LUserToken>();
            services.AddScoped<ILUser, LUser>();

            return services;
        }
    }
}
