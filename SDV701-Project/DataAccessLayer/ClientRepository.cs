using DataAccessLayer.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing client entities in the database.
    /// </summary>
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ClientRepository(ModelContext context) : base(context)
        {

        }

        /// <summary>
        /// Retrieves a client by its identifier, including related pet owners and bookings.
        /// </summary>
        /// <param name="id">The identifier of the client.</param>
        /// <returns>The client if found; otherwise, null.</returns>
        public virtual Client Get(int id)
        {
            return All.Include(c => c.PetOwners)
                      .ThenInclude(po => po.Pet)
                      .Include(c => c.Bookings)
                      .ThenInclude(b => b.Room)
                      .FirstOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// Deletes a client by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the client to delete.</param>
        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// Retrieves all clients, including related pet owners and bookings.
        /// </summary>
        /// <returns>A collection of all clients.</returns>
        public override IEnumerable<Client> List()
        {
            return All.Include(c => c.PetOwners)
                      .ThenInclude(po => po.Pet)
                      .Include(c => c.Bookings)
                      .OfType<Client>()
                      .ToList();
        }

        /// <summary>
        /// Searches for clients based on specified filters, including related pet owners and bookings.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A collection of clients that match the filters.</returns>
        public virtual IEnumerable<Client> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Clients
                .Include(c => c.PetOwners)
                .ThenInclude(po => po.Pet)
                .Include(c => c.Bookings)
                .ThenInclude(b => b.Room)
                .AsNoTracking();

            var predicate = PredicateBuilder.New<Client>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Client>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;
                    var filterName = filter.FilterName.ToLower();

                    if (filterName == "Name")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Client>(c => c.Name, filter));
                    }

                    else if (filterName == "Email")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Client>(c => c.Email, filter));
                    }

                    else if (filterName == "Phone")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Client>(c => c.Phone, filter));
                    }

                    else if (filterName == "Pet")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Client>(c => c.PetOwners.Select(po => po.Pet.Name).FirstOrDefault(), filter));
                    }

                    else if (filterName == "ID")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Client>(p => p.ID, filter));
                    }
                }

                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate).ToList();
        }
    }
}
