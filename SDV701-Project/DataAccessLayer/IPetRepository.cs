using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IPetRepository
    {
        void Delete(int id);
        Pet Get(int id);
        IEnumerable<T> List<T>();
        IEnumerable<T> List<T>(int ownerID);
    }
}