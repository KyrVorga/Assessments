using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class TimelineEvent
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public string Type { get; set; }
        public DateTime EventTime { get; set; }
        public string? Time { get; set; }
        public DaysOfWeekEnum? DaysOfWeek { get; set; }
        public int? WeekInterval { get; set; }
        public string? MonthDays { get; set; }
        public string Repetition { get; set; }
        public int? EndAfter { get; set; }
        public DateTime? EndBefore { get; set; }
        public string? Notes { get; set; }
        public string EventName { get; set; }
        public string PetName { get; set; }
        public string? RoomNumber { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{EventName} for {PetName}");

            // Customize output based on Type
            switch (Type)
            {
                case "Daily":
                    sb.Append($" every day at {Time}");
                    break;
                case "Weekly":
                    sb.Append($" every week on {DaysOfWeek}");
                    if (WeekInterval.HasValue)
                    {
                        sb.Append($" every {WeekInterval} weeks");
                    }
                    break;
                case "Monthly":
                    sb.Append($" on day {MonthDays} of the month");
                    break;
                default:
                    sb.Append($" on {EventTime.ToShortDateString()} at {EventTime.ToShortTimeString()}");
                    break;
            }

            if (!string.IsNullOrEmpty(RoomNumber))
            {
                sb.Append($", in room {RoomNumber}");
            }

            if (EndBefore.HasValue)
            {
                sb.Append($", until {EndBefore.Value.ToShortDateString()}");
            }

            return sb.ToString();
        }
    }
}
