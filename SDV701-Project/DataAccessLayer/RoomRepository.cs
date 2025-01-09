using DataAccessLayer.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing Room entities in the database.
    /// </summary>
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public RoomRepository(ModelContext context) : base(context)
        {

        }

        /// <summary>
        /// Retrieves a Room entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Room.</param>
        /// <returns>The <see cref="Room"/> entity if found; otherwise, null.</returns>
        public virtual Room Get(int id)
        {
            return All.FirstOrDefault(a => a.ID == id);
        }

        /// <summary>
        /// Deletes a Room entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Room to delete.</param>
        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// Lists all Room entities.
        /// </summary>
        /// <returns>An enumerable of <see cref="Room"/> entities.</returns>
        public override IEnumerable<Room> List()
        {
            return All.OfType<Room>().ToList();
        }

        /// <summary>
        /// Searches for Room entities based on a set of filters.
        /// </summary>
        /// <param name="filters">A dictionary containing the filters to apply.</param>
        /// <returns>An enumerable of <see cref="Room"/> entities that match the filters.</returns>
        public virtual IEnumerable<Room> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Rooms
                .Include(a => a.Bookings)
                .AsNoTracking();

            var predicate = PredicateBuilder.New<Room>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Room>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;
                    var filterName = filter.FilterName.ToLower();

                    if (filterName == "number")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Room>(a => a.Number, filter));
                    }

                    else if (filterName == "quality")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Room>(a => a.Quality, filter));
                    }

                    else if (filterName == "size")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Room>(a => a.Size, filter));
                    }

                    else if (filterName == "status")
                    {
                        innerPredicate = innerPredicate.Or(GetBoolFilterExpression<Room>(a => a.Status, filter));
                    }
                    else if (filterName == "date")
                    {

                        var dates = filter.Value.ToString().Split(' ');
                        DateTime startDate = DateTime.Parse(dates[0]);
                        DateTime endDate = DateTime.Parse(dates[1]);

                        // This predicate checks if all bookings of a room are outside the given date range
                        innerPredicate = innerPredicate.Or(room => room.Bookings.All(booking =>
                            booking.CheckIn < startDate || booking.CheckOut > endDate));

                    }

                }

                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate);
        }
    }
}
