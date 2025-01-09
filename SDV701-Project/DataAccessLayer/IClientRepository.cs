using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IClientRepository
    {
        void Delete(int id);
        Client Get(int id);
    }
}