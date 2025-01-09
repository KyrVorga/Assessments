namespace DataAccessLayer.Models
{
    public class PetOwner
    {
        public int ClientID { get; set; }
        public int PetID { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Pet? Pet { get; set; }
    }

}
