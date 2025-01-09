using System.Text.Json.Serialization;

namespace Models
{
    public class VeterinarianModel : IVeterinarianModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("contact_person")]
        public string? ContactPerson { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("schedule_id")]
        public int? ScheduleID { get; set; }

        public override string ToString()
        {
            return $"{Name} - {ContactPerson}";
        }
    }
}