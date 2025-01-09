using SharedLibrary;

namespace DataAccessLayer.Models
{
    public partial class Room
    {

        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ID { get; set; }
        public int Number { get; set; }
        public string Quality { get; set; }
        public string? Size { get; set; }
        public bool Status { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public QualityEnum GetQualityType()
        {
            return (QualityEnum)Enum.Parse(typeof(QualityEnum), Quality);
        }

        public void SetQualityType(QualityEnum type)
        {
            Quality = type.ToString();
        }

        public SizeEnum GetSizeType()
        {
            return (SizeEnum)Enum.Parse(typeof(SizeEnum), Size);
        }

        public void SetSizeType(SizeEnum type)
        {
            Size = type.ToString();
        }

        public StatusEnum GetStatusType()
        {
            return (StatusEnum)Enum.Parse(typeof(StatusEnum), Status.ToString());
        }

        public void SetStatusType(StatusEnum type)
        {
            Status = type == StatusEnum.Available ? true : false;
        }
    }
}
