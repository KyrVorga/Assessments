namespace DataAccessLayer.Models
{
    public partial class Bird : Pet
    {
        public string? Species { get; set; }
        public string? SpaceRequirements { get; set; }
    }
}
