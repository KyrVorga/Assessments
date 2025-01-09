using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IVeterinarianRepository
    {
        Veterinarian Get(int veterinarianID);
        IEnumerable<Veterinarian> GetAll();
        IEnumerable<Veterinarian> Search(Dictionary<string, List<FilterCriteria>> filters);
    }
}