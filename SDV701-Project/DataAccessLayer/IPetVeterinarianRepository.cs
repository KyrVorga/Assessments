using DataAccessLayer.Models;

namespace DataAccessLayer
{
    internal interface IPetVeterinarianRepository
    {
        PetVeterinarian Get(int petID, int veterinarianID);
        List<PetVeterinarian> GetAll();
    }
}