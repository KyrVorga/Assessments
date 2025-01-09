
using SharedLibrary;
using System.Text.Json.Serialization;

namespace Models
{
    public interface ITaskModel : IEntityModel
    {
        int ID { get; set; }
        string Measurement { get; set; }
        string Name { get; set; }
        string? Notes { get; set; }
        int Quantity { get; set; }
        int? PetID { get; set; }
        int? BookingID { get; set; }
        DateTime? TaskDate { get; set; }
        string Type { get; set; }
    }
}