using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IPetOwnerRepository
    {
        void Delete(int clientID, int petID);
        void DeleteOwner(int clientID);
        void DeletePet(int petID);
        PetOwner Get(int clientID, int petID);
        List<PetOwner> GetAll();
    }
}