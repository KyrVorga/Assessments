using DataAccessLayer.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing Veterinarian entities in the database.
    /// </summary>
    public class VeterinarianRepository : Repository<Veterinarian>, IVeterinarianRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public VeterinarianRepository(ModelContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves a Veterinarian entity by its ID.
        /// </summary>
        /// <param name="veterinarianID">The ID of the Veterinarian.</param>
        /// <returns>The <see cref="Veterinarian"/> entity if found; otherwise, null.</returns>
        public virtual Veterinarian Get(int veterinarianID)
        {
            return All.FirstOrDefault(a => a.ID == veterinarianID);
        }

        /// <summary>
        /// Retrieves all Veterinarian entities.
        /// </summary>
        /// <returns>An enumerable of <see cref="Veterinarian"/> entities.</returns>
        public virtual IEnumerable<Veterinarian> GetAll() { return All.ToList(); }

        /// <summary>
        /// Searches for Veterinarian entities based on a set of filters.
        /// </summary>
        /// <param name="filters">A dictionary containing the filters to apply.</param>
        /// <returns>An enumerable of <see cref="Veterinarian"/> entities that match the filters.</returns>
        public virtual IEnumerable<Veterinarian> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Veterinarians.AsNoTracking();

            var predicate = PredicateBuilder.New<Veterinarian>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Veterinarian>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;
                    var filterName = filter.FilterName.ToLower();

                    if (filterName == "Name")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Veterinarian>(c => c.Name, filter));
                    }

                    else if (filterName == "ID")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Veterinarian>(p => p.ID, filter));
                    }

                    else if (filterName == "Contact Person")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Veterinarian>(c => c.ContactPerson, filter));
                    }

                    else if (filterName == "Phone")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Veterinarian>(c => c.Phone, filter));
                    }

                    else if (filterName == "Email")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Veterinarian>(c => c.Email, filter));
                    }
                }

                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate).ToList();
        }
    }
}
