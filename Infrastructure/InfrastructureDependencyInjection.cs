using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    /// <summary>
    /// Contains the extensions method for registering dependencies in the DI framework.
    /// </summary>
    public static class InfrastructureDependencyInjection
	{
        /// <summary>
        /// Register the necesary services with the DI Framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The same service collection.</returns>
		public static IServiceCollection AddInfrastructure(this IServiceCollection services) => services;
    }
}
