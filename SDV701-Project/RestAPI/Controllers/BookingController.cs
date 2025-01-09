using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : GenericController<IBookingService, BookingModel>
    {
        public BookingController(IBookingService bookingService) : base(bookingService)
        {
        }

        // GET api/booking/timeline
        [HttpGet("timeline")]
        public virtual IList<TimelineEvent> GetTimelineEvents([FromQuery] List<int> bookingIds = null)
        {

            return Service.GetTimelineEvents(bookingIds);
        }
    }
}
