namespace Models
{
    public interface IVeterinarianModel : IEntityModel
    {
        string? Address { get; set; }
        string? ContactPerson { get; set; }
        string? Email { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string? Notes { get; set; }
        string Phone { get; set; }
        int? ScheduleID { get; set; }
    }
}