using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class PetTraitRepository : Repository<PetTrait>, IPetTraitRepository
    {
        public PetTraitRepository(ModelContext context) : base(context) { }

        public virtual PetTrait Get(int petID, int traitID)
        {
            return All.FirstOrDefault(a => a.PetID == petID && a.TraitID == traitID);
        }
        public virtual List<PetTrait> GetAll() { return All.ToList(); }
    }
}
