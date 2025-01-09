using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {

            // Ensure database is created
            Database.EnsureCreated();
        }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetOwner> PetOwners { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Veterinarian> Veterinarians { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<PetVeterinarian> PetVeterinarians { get; set; }
        public virtual DbSet<PetTrait> PetTraits { get; set; }
        public virtual DbSet<Trait> Traits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // call the base onConfiguring method
            base.OnConfiguring(optionsBuilder);

        }

        /// <summary>
        /// Configures the schema needed for the model used in the database context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
                entity.HasOne(e => e.Client)
                    .WithMany(e => e.Bookings)
                    .HasForeignKey(e => e.ClientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Client");
                entity.HasOne(e => e.Room)
                    .WithMany(e => e.Bookings)
                    .HasForeignKey(e => e.RoomID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Room");
                entity.HasOne(e => e.Pet)
                    .WithMany(e => e.Bookings)
                    .HasForeignKey(e => e.PetID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Pet");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(e => e.Email)
                    .HasMaxLength(75);
                entity.Property(e => e.Address)
                    .HasMaxLength(100);
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");
                entity.HasDiscriminator<string>("PetType")
                    .HasValue<Bird>("Bird")
                    .HasValue<Cat>("Cat");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Colour)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.YearOfBirth);
                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(25);
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
                entity.HasMany(e => e.Tasks)
                    .WithOne(e => e.Pet)
                    .HasForeignKey(e => e.PetID)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Bird>(entity =>
            {
                entity.ToTable("Pet");
                entity.Property(e => e.Species)
                    .HasMaxLength(100);
                entity.Property(e => e.SpaceRequirements)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("Pet");
                entity.Property(e => e.Breed)
                    .HasMaxLength(100);
                entity.Property(e => e.Neutered)
                    .IsRequired();
                entity.Property(e => e.Microchipped)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");
                entity.Property(e => e.Number)
                    .IsRequired();
                entity.Property(e => e.Quality)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Status)
                    .IsRequired();
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
                entity.Property(e => e.Size)
                    .IsRequired();
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Time)
                    .IsRequired();
                entity.Property(e => e.DaysOfWeek)
                    .IsRequired()
                    .HasConversion<int>();
                entity.Property(e => e.WeekInterval);
                entity.Property(e => e.MonthDays)
                    .HasMaxLength(50);
                entity.Property(e => e.Repetition)
                    .HasMaxLength(50);
                entity.Property(e => e.EndAfter);
                entity.Property(e => e.EndBefore);
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
                entity.HasOne<Models.Task>()
                    .WithMany(e => e.Schedules)
                    .HasForeignKey(e => e.TaskID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.ToTable("Task");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Quantity)
                    .HasMaxLength(50);
                entity.Property(e => e.Measurement)
                    .HasMaxLength(50);
                entity.Property(e => e.TaskDate);
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
                entity.HasMany(e => e.Schedules)
                    .WithOne(e => e.Task)
                    .HasForeignKey(e => e.TaskID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_Task");
            });

            modelBuilder.Entity<Veterinarian>(entity =>
            {
                entity.ToTable("Veterinarian");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(e => e.Email)
                    .HasMaxLength(75);
                entity.Property(e => e.Address)
                    .HasMaxLength(100);
                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);
            });


            modelBuilder.Entity<PetVeterinarian>(entity =>
            {
                entity.ToTable("PetVeterinarian");
                entity.HasKey(e => new { e.PetID, e.VeterinarianID });
                entity.HasOne(e => e.Pet)
                    .WithMany(e => e.PetVeterinarians)
                    .HasForeignKey(e => e.PetID);
                entity.HasOne(e => e.Veterinarian)
                    .WithMany(e => e.PetVeterinarians)
                    .HasForeignKey(e => e.VeterinarianID);
            });

            modelBuilder.Entity<PetOwner>(entity =>
            {
                entity.ToTable("PetOwner");
                entity.HasKey(e => new { e.ClientID, e.PetID });
                entity.HasOne(e => e.Client)
                    .WithMany(e => e.PetOwners)
                    .HasForeignKey(e => e.ClientID);
                entity.HasOne(e => e.Pet)
                    .WithMany(e => e.PetOwners)
                    .HasForeignKey(e => e.PetID);
            });

            modelBuilder.Entity<PetTrait>(entity =>
            {
                entity.ToTable("PetTrait");
                entity.HasKey(e => new { e.PetID, e.TraitID });
                entity.HasOne(e => e.Pet)
                    .WithMany(e => e.PetTraits)
                    .HasForeignKey(e => e.PetID);
                entity.HasOne(e => e.Trait)
                    .WithMany(e => e.PetTraits)
                    .HasForeignKey(e => e.TraitID);
            });

            modelBuilder.Entity<Trait>(entity =>
            {
                entity.ToTable("Trait");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Description)
                    .HasMaxLength(1000);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}