namespace DataAccessLayer.Models
{
    public partial class Cat : Pet
    {
        public string? Breed { get; set; }
        public bool? Neutered { get; set; }
        public bool? Microchipped { get; set; }
    }
}
