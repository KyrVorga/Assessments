using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharedLibrary;

namespace Models
{
    public class TaskModel : ITaskModel
    {

        [Required]
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("measurement")]
        public string Measurement { get; set; }

        [JsonPropertyName("date")]
        public DateTime? TaskDate { get; set; }

        [JsonPropertyName("pet_id")]
        public int? PetID { get; set; }

        [JsonPropertyName("pet_id")]
        public int? BookingID { get; set; }

        [StringLength(1000)]
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("schedules")]
        public IList<int>? ScheduleIDs { get; set; }


        public MeasurementEnum GetMeasurementType()
        {
            return (MeasurementEnum)Enum.Parse(typeof(MeasurementEnum), Measurement);
        }

        public void SetMeasurementType(MeasurementEnum type)
        {
            Measurement = type.ToString();
        }

        public TaskTypeEnum GetTaskType()
        {
            return (TaskTypeEnum)Enum.Parse(typeof(TaskTypeEnum), Type);
        }

        public void SetTaskType(TaskTypeEnum type)
        {
            Type = type.ToString();
        }

        public override string ToString()
        {
            return $"{Name} - {Type}";
        }
    }
}