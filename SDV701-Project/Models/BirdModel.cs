using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class BirdModel : PetModel
    {
        [JsonPropertyName("species")]
        public string? Species { get; set; }

        [JsonPropertyName("space_requirements")]
        public string? SpaceRequirements { get; set; }
    }
}
