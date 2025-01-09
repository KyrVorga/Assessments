namespace DataAccessLayer.Models
{
    public partial class Client
    {
        public Client()
        {
            PetOwners = new HashSet<PetOwner>();
            Bookings = new HashSet<Booking>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }

        public ICollection<PetOwner> PetOwners { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
