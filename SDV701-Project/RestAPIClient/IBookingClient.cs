using Models;
using SharedLibrary;

namespace RestAPIClient
{
    public interface IBookingClient : IAPIClient<BookingModel>
    {
        Task<IList<TimelineEvent>> GetTimelineEventsAsync(List<int> bookingIds = null);
    }
}