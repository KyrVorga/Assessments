using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IRoomRepository
    {
        void Delete(int id);
        Room Get(int id);
    }
}