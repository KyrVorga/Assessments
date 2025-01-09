using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class BookingModel : IBookingModel
    {
        [Required]
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [JsonPropertyName("client_id")]
        public int? ClientID { get; set; }

        [Required]
        [JsonPropertyName("room_id")]
        public int? RoomID { get; set; }

        [Required]
        [JsonPropertyName("pet_id")]
        public int? PetID { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [Required]
        [JsonPropertyName("check_in")]
        public DateTime CheckIn { get; set; }

        [JsonPropertyName("check_out")]
        public DateTime? CheckOut { get; set; }
    }
}
