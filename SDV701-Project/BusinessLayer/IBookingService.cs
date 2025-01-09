using Models;
using SharedLibrary;

namespace BusinessLayer
{
    public interface IBookingService : IService<BookingModel>
    {
        IList<TimelineEvent> GetTimelineEvents(List<int> bookingIds = null);
        IList<BookingModel> Search(Dictionary<string, List<FilterCriteria>> filters);
    }
}