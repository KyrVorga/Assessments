namespace DataAccessLayer.Models
{
    public class PetTrait
    {
        public int PetID { get; set; }
        public int TraitID { get; set; }
        public virtual Pet? Pet { get; set; }
        public virtual Trait? Trait { get; set; }
    }
}
