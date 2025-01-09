
namespace Models
{
    public interface IPetModel : IEntityModel
    {
        string Colour { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string? Notes { get; set; }
        IList<int> OwnerIDs { get; set; }
        IList<int> BookingIDs { get; set; }
        string Sex { get; set; }
        int? YearOfBirth { get; set; }
        IList<int> VeterinarianIDs { get; set; }
    }
}