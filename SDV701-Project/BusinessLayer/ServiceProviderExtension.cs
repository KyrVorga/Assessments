using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/> to register business layer services.
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// Registers business layer services into the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="container">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> with registered services.</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection container)
        {
            container.AddAutoMapper(typeof(MappingProfile));

            container.AddScoped<IClientService, ClientService>();
            container.AddScoped<IBookingService, BookingService>();
            container.AddScoped<ICatService, CatService>();
            container.AddScoped<IBirdService, BirdService>();
            container.AddScoped<IPetService, PetService>();
            container.AddScoped<IRoomService, RoomService>();
            container.AddScoped<IScheduleService, ScheduleService>();
            container.AddScoped<ITaskService, TaskService>();
            container.AddScoped<ITraitService, TraitService>();
            container.AddScoped<IVeterinarianService, VeterinarianService>();

            return container;
        }
    }
}
