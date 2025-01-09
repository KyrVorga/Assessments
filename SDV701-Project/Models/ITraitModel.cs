namespace Models
{
    public interface ITraitModel : IEntityModel
    {
        string? Description { get; set; }
        int ID { get; set; }
        string Name { get; set; }
    }
}