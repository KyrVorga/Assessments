using Microsoft.Extensions.DependencyInjection;

namespace RestAPIClient
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/> to register REST API clients.
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// Registers HTTP client and scoped services for API clients into the DI container.
        /// </summary>
        /// <param name="container">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection RegisterClients(this IServiceCollection container)
        {
            container.AddHttpClient();
            container.AddScoped<IClientClient, ClientClient>();

            container.AddScoped<ICatClient, CatClient>();
            container.AddScoped<IBirdClient, BirdClient>();
            container.AddScoped<IPetClient, PetClient>();

            container.AddScoped<IBookingClient, BookingClient>();
            container.AddScoped<IRoomClient, RoomClient>();

            return container;
        }
    }
}
