namespace DataAccessLayer.Models
{
    public partial class Veterinarian
    {
        public Veterinarian()
        {
            PetVeterinarians = new HashSet<PetVeterinarian>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string? ContactPerson { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public int? ScheduleID { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<PetVeterinarian> PetVeterinarians { get; set; }
    }
}
