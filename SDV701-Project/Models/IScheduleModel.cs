using SharedLibrary;

namespace Models
{
    public interface IScheduleModel : IEntityModel
    {
        DaysOfWeekEnum? DaysOfWeek { get; set; }
        int? EndAfter { get; set; }
        DateTime? EndBefore { get; set; }
        int ID { get; set; }
        string? MonthDays { get; set; }
        string? Notes { get; set; }
        string? Repetition { get; set; }
        int OwnerID { get; set; }
        string Time { get; set; }
        string Type { get; set; }
        int? WeekInterval { get; set; }
    }
}