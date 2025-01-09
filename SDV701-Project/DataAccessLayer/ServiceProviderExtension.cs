using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/> to register
    /// data access layer services and repositories.
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// Registers repository interfaces and their implementations to the service collection.
        /// </summary>
        /// <param name="container">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection RegisterRepositories(this IServiceCollection container)
        {
            container.AddScoped<IUnitOfWork, UnitOfWork>();
            container.AddScoped<IClientRepository, ClientRepository>();
            container.AddScoped<IBookingRepository, BookingRepository>();
            container.AddScoped<IPetRepository, PetRepository>();
            container.AddScoped<IRoomRepository, RoomRepository>();
            container.AddScoped<IVeterinarianRepository, VeterinarianRepository>();
            container.AddScoped<ITaskRepository, TaskRepository>();
            container.AddScoped<ITraitRepository, TraitRepository>();
            container.AddScoped<IScheduleRepository, ScheduleRepository>();
            container.AddScoped<IPetOwnerRepository, PetOwnerRepository>();
            container.AddScoped<IPetTraitRepository, PetTraitRepository>();
            container.AddScoped<IPetVeterinarianRepository, PetVeterinarianRepository>();

            return container;
        }

        /// <summary>
        /// Registers the database context with the specified connection string to the service collection.
        /// </summary>
        /// <param name="container">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="connectionString">The database connection string.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection RegisterDbContext(this IServiceCollection container, string connectionString)
        {
            container.AddDbContext<ModelContext>(options => options.UseSqlServer(connectionString));
            return container;
        }
    }
}
