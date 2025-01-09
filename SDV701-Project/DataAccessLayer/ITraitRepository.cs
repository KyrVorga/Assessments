using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface ITraitRepository
    {
        void Delete(int id);
        Trait Get(int id);
    }
}