using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class CatModel : PetModel
    {
        [JsonPropertyName("breed")]
        public string? Breed { get; set; }

        [JsonPropertyName("neutered")]
        public bool? Neutered { get; set; }

        [JsonPropertyName("microchipped")]
        public bool? Microchipped { get; set; }
    }
}
