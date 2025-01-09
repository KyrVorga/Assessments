
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public interface IBookingModel : IEntityModel
    {
        int? ClientID { get; set; }
        int ID { get; set; }
        string? Notes { get; set; }
        int? PetID { get; set; }
        int? RoomID { get; set; }
        DateTime CheckIn { get; set; }
        DateTime? CheckOut { get; set; }
    }
}