using SharedLibrary;

namespace DataAccessLayer.Models
{
    public partial class Schedule
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public DaysOfWeekEnum? DaysOfWeek { get; set; } = DaysOfWeekEnum.None;
        public int? WeekInterval { get; set; }
        public string? MonthDays { get; set; }
        public string? Repetition { get; set; }
        public int? EndAfter { get; set; }
        public DateTime? EndBefore { get; set; }
        public string? Notes { get; set; }

        public Task Task { get; set; }


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
    }

}
