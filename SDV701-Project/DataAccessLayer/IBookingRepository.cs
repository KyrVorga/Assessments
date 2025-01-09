using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IBookingRepository
    {
        void Delete(int id);
        Booking Get(int id);
        IEnumerable<Booking> Search(Dictionary<string, List<FilterCriteria>> searchParameters);
    }
}