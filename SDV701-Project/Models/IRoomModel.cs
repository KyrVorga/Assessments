using SharedLibrary;

namespace Models
{
    public interface IRoomModel : IEntityModel
    {
        int ID { get; set; }
        string? Notes { get; set; }
        int Number { get; set; }
        string Quality { get; set; }
        string Size { get; set; }
        bool Status { get; set; }
    }
}