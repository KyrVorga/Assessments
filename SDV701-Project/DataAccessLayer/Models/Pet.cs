namespace DataAccessLayer.Models
{
    public abstract class Pet
    {
        public Pet()
        {
            Bookings = new HashSet<Booking>();
            PetOwners = new HashSet<PetOwner>();
            PetVeterinarians = new HashSet<PetVeterinarian>();
            Tasks = new HashSet<Task>();
            PetTraits = new HashSet<PetTrait>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public int? YearOfBirth { get; set; }
        public string Sex { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<PetOwner> PetOwners { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<PetVeterinarian> PetVeterinarians { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<PetTrait> PetTraits { get; set; }
    }
}
