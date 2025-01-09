namespace DataAccessLayer.Models
{
    public class Trait
    {
        public Trait()
        {
            PetTraits = new HashSet<PetTrait>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<PetTrait> PetTraits { get; set; }
    }
}
