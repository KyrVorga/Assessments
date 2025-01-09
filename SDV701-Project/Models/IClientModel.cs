namespace Models
{
    public interface IClientModel : IEntityModel
    {
        string Address { get; set; }
        string Email { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        IList<int> PetIDs { get; set; }
        IList<int> BookingIDs { get; set; }

        string Phone { get; set; }
    }
}