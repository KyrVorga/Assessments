using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class ClientModel : IClientModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [StringLength(75)]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [StringLength(100)]
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [StringLength(1000)]
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("pets")]
        public IList<int> PetIDs { get; set; }


        [JsonPropertyName("bookings")]
        public IList<int> BookingIDs { get; set; }


        public ClientModel()
        {
            PetIDs = new List<int>();
            BookingIDs = new List<int>();
        }

        public override string ToString()
        {
            return $"{Name} - {Phone}";
        }
    }
}
