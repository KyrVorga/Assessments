using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using SharedLibrary;

namespace Models
{
    public class ScheduleModel : IScheduleModel, IEntityModel
    {
        [Required]
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [JsonPropertyName("owner")]
        public int OwnerID { get; set; }

        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Required]
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("days_of_week")]
        public DaysOfWeekEnum? DaysOfWeek { get; set; } = DaysOfWeekEnum.None;

        [JsonPropertyName("week_interval")]
        public int? WeekInterval { get; set; }

        [JsonPropertyName("days_of_month")]
        public string? MonthDays { get; set; }

        [JsonPropertyName("repetition")]
        public string Repetition { get; set; }

        [JsonPropertyName("end_after")]
        public int? EndAfter { get; set; }

        [JsonPropertyName("end_before")]
        public DateTime? EndBefore { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }
        

        public FrequencyEnum GetFrequencyType()
        {
            return (FrequencyEnum)Enum.Parse(typeof(FrequencyEnum), Type);
        }

        public void SetFrequencyType(FrequencyEnum type)
        {
            Type = type.ToString();
        }

        public RepetitionEnum GetRepetitionEnum()
        {
            return (RepetitionEnum)Enum.Parse(typeof(RepetitionEnum), Repetition);
        }

        public void SetRepetitionEnum(RepetitionEnum type)
        {
            Repetition = type.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Type);
            if (Type == FrequencyEnum.Daily.ToString())
            {
                sb.Append(" at ");
                sb.Append(Time);
            }
            else if (Type == FrequencyEnum.Weekly.ToString())
            {
                sb.Append(" on ");
                sb.Append(DaysOfWeek);
                if (WeekInterval.HasValue)
                {
                    sb.Append(" every ");
                    sb.Append(WeekInterval);
                    sb.Append(" weeks");
                }
            }
            else if (Type == FrequencyEnum.Monthly.ToString())
            {
                sb.Append(" on ");
                sb.Append(MonthDays);
            }
            return sb.ToString();
        }
    }
}