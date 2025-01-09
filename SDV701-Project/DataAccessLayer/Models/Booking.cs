namespace DataAccessLayer.Models
{
    public partial class Booking
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public int? RoomID { get; set; }
        public int? PetID { get; set; }
        public string? Notes { get; set; }
        public virtual Pet? Pet { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Client? Client { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
