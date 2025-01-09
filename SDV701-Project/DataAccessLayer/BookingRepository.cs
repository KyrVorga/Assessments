using DataAccessLayer.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing bookings in the database.
    /// </summary>
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BookingRepository(ModelContext context) : base(context)
        {

        }

        /// <summary>
        /// Retrieves a booking by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the booking.</param>
        /// <returns>The booking if found; otherwise, null.</returns>
        public virtual Booking Get(int id)
        {
            return All.FirstOrDefault(a => a.ID == id);
        }

        /// <summary>
        /// Deletes a booking by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the booking to delete.</param>
        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// Searches for bookings based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A collection of bookings that match the filters.</returns>
        public virtual IEnumerable<Booking> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Pet)
                .Include(b => b.Room)
                .AsQueryable();

            var predicate = PredicateBuilder.New<Booking>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Booking>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;
                    var filterName = filter.FilterName.ToLower();

                    if (filterName == "Client")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Booking>(a => a.Client.Name, filter));
                    }

                    else if (filterName == "Pet")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Booking>(a => a.Pet.Name, filter));
                    }

                    else if (filterName == "Room")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Booking>(a => a.Room.Number, filter));
                    }
                    else if (filterName == "CheckIn")
                    {
                        innerPredicate = innerPredicate.Or(GetDateFilterExpression<Booking>(a => a.CheckIn, filter));
                    }
    
                    else if (filterName == "CheckOut")
                    {
                        innerPredicate = innerPredicate.Or(GetDateFilterExpression<Booking>(a => a.CheckOut, filter));
                    }
                    else if (filterName == "Date")
                    {
                        innerPredicate = innerPredicate.Or(GetDateFilterExpression<Booking>(a => a.CheckIn, filter));
                        innerPredicate = innerPredicate.Or(GetDateFilterExpression<Booking>(a => a.CheckOut, filter));
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid filter name");
                    }

                }
                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate).ToList();
        }

        /// <summary>
        /// Retrieves a list of TimelineEvent objects for a specified list of Booking IDs.
        /// </summary>
        /// <param name="bookingIds">An optional list of Booking IDs to filter the events by.</param>
        /// <returns>A list of <see cref="TimelineEvent"/> objects.</returns>
        public IList<TimelineEvent> GetTimelineEvents(List<int> bookingIds = null)
        {
            var timelineEvents = new List<TimelineEvent>();

            // Get all of the bookings and extra data
            IQueryable<Booking> bookingsQuery = Context.Bookings
                .Include(t => t.Client)
                .Include(t => t.Pet)
                .Include(t => t.Room);

            // If a list of IDs is provided, filter the bookings
            if (bookingIds != null && bookingIds.Count > 0)
            {
                bookingsQuery = bookingsQuery.Where(t => bookingIds.Contains(t.ID));
            }

            var bookings = bookingsQuery.ToList();

            foreach (var booking in bookings)
            {
                // Create a timeline event for the check-in
                var checkInEvent = new TimelineEvent
                {
                    Type = "Booking",
                    EventName = booking.Client.Name,
                    PetName = booking.Pet.Name,
                    RoomNumber = booking.Room.Number.ToString(),
                    EventTime = booking.CheckIn,
                    Time = booking.CheckIn.ToString(),
                };

                // Skip the next part if Checkout is null
                if (booking.CheckOut == null)
                {
                    timelineEvents.Add(checkInEvent);
                    continue;
                }

                // Create a timeline event for the check-out
                var checkOutEvent = new TimelineEvent
                {
                    Type = "Booking",
                    EventName = booking.Client.Name,
                    PetName = booking.Pet.Name,
                    RoomNumber = booking.Room.Number.ToString(),
                    EventTime = (DateTime)booking.CheckOut,
                    Time = booking.CheckOut.ToString(),
                };

                // Add the check-in and check-out events to the timeline
                timelineEvents.Add(checkInEvent);
                timelineEvents.Add(checkOutEvent);
            }

            return timelineEvents;
        }
    }
}
