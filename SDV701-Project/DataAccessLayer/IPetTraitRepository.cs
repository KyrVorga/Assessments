using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IPetTraitRepository
    {
        PetTrait Get(int petID, int traitID);
        List<PetTrait> GetAll();
    }
}