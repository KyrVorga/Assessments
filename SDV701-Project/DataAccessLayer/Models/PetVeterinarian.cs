namespace DataAccessLayer.Models
{
    public class PetVeterinarian
    {
        public int PetID { get; set; }
        public int VeterinarianID { get; set; }
        public virtual Pet? Pet { get; set; }
        public virtual Veterinarian? Veterinarian { get; set; }
    }
}
