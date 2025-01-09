using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class PetModel : IPetModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("year_of_birth")]
        public int? YearOfBirth { get; set; }

        [StringLength(75)]
        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        [StringLength(75)]
        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [StringLength(1000)]
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("pet_owners")]
        public IList<int> OwnerIDs { get; set; }

        [JsonPropertyName("bookings")]
        public IList<int> BookingIDs { get; set; }
        public IList<int> TraitIDs { get; set; }
        public IList<int> VeterinarianIDs { get; set; }
        public PetModel()
        {
            OwnerIDs = new List<int>();
            BookingIDs = new List<int>();
            TraitIDs = new List<int>();
            VeterinarianIDs = new List<int>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
