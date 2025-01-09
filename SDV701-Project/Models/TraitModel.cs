using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class TraitModel : ITraitModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
