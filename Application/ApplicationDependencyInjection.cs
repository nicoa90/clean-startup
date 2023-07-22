using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    /// <summary>
    /// Contains the extensions method for registering dependencies in the DI framework.
    /// </summary>
    public static class ApplicationDependencyInjection
	{
        /// <summary>
        /// Register the necesary services with the DI Framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The same service collection.</returns>
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			var assembly = typeof(ApplicationDependencyInjection).Assembly;

			services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
			services.AddValidatorsFromAssembly(assembly);

			return services;
		}
	}
}
