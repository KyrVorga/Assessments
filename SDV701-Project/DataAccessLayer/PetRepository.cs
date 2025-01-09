using DataAccessLayer.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing Pet entities in the database.
    /// </summary>
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PetRepository(ModelContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves a Pet entity by its ID, including related entities.
        /// </summary>
        /// <param name="id">The ID of the Pet.</param>
        /// <returns>The <see cref="Pet"/> entity if found; otherwise, null.</returns>
        public virtual Pet Get(int id)
        {
            return All.Include(p => p.PetOwners)
                      .ThenInclude(po => po.Client)
                      .Include(p => p.PetVeterinarians)
                      .ThenInclude(pv => pv.Veterinarian)
                      .Include(p => p.Bookings)
                      .FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Deletes a Pet entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Pet to delete.</param>
        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// Lists all Pet entities of a specific type related to a given owner.
        /// </summary>
        /// <typeparam name="T">The type of Pet entities to list.</typeparam>
        /// <param name="ownerID">The ID of the owner.</param>
        /// <returns>An enumerable of Pet entities of the specified type.</returns>
        public virtual IEnumerable<T> List<T>(int ownerID)
        {
            return All.Include(p => p.PetOwners)
                      .Where(p => p.PetOwners.Any(po => po.ClientID == ownerID))
                      .Include(p => p.PetVeterinarians)
                      .Include(p => p.Bookings)
                      .OfType<T>()
                      .ToList();
        }

        /// <summary>
        /// Lists all Pet entities of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of Pet entities to list.</typeparam>
        /// <returns>An enumerable of Pet entities of the specified type.</returns>
        public virtual IEnumerable<T> List<T>()
        {
            return All.Include(p => p.PetOwners)
                .ThenInclude(po => po.Client)
                .Include(p => p.PetVeterinarians)
                .Include(p => p.Bookings)
                .OfType<T>()
                .ToList();
        }

        /// <summary>
        /// Searches for Pet entities based on a set of filters.
        /// </summary>
        /// <param name="filters">A dictionary containing the filters to apply.</param>
        /// <returns>An enumerable of Pet entities that match the filters.</returns>
        public virtual IEnumerable<Pet> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Pets
                .Include(p => p.PetOwners)
                .ThenInclude(po => po.Client)
                .Include(p => p.PetVeterinarians)
                .Include(p => p.Bookings)
                .AsNoTracking();

            var predicate = PredicateBuilder.New<Pet>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Pet>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;
                    var filterName = filter.FilterName.ToLower();

                    if (filterName == "Name")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Pet>(p => p.Name, filter));
                    }

                    else if (filterName == "Client")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Pet>(p => p.PetOwners.FirstOrDefault().Client.Name, filter));
                    }

                    else if (filterName == "Owner")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Pet>(p => p.PetOwners.FirstOrDefault().Client.Name, filter));
                    }
                    else if (filterName == "ID")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Pet>(p => p.ID, filter));
                    }
                }

                predicate = predicate.And(innerPredicate);
            }

            return result.Where(predicate).ToList();
        }

        /// <summary>
        /// Searches for Cat entities based on a set of filters.
        /// </summary>
        /// <param name="filters">A dictionary containing the filters to apply.</param>
        /// <returns>An enumerable of Cat entities that match the filters.</returns>
        public virtual IEnumerable<Cat> CatSearch(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Pets
                .Include(p => p.PetOwners)
                .ThenInclude(po => po.Client)
                .Include(p => p.PetVeterinarians)
                .Include(p => p.Bookings)
                .AsNoTracking()
                .OfType<Cat>();

            var predicate = PredicateBuilder.New<Cat>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Cat>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;

                    if (filter.FilterName == "Name")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Cat>(p => p.Name, filter));
                    }

                    else if (filter.FilterName == "Client")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Cat>(p => p.PetOwners.FirstOrDefault().Client.Name, filter));
                    }

                    else if (filter.FilterName == "Owner")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Cat>(p => p.PetOwners.FirstOrDefault().Client.Name, filter));
                    }
                    else if (filter.FilterName == "ID")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Cat>(p => p.ID, filter));
                    }
                    else if (filter.FilterName == "Breed")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Cat>(p => p.Breed, filter));
                    }
                    else if (filter.FilterName == "Colour")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Cat>(p => p.Colour, filter));
                    }
                }

                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate).ToList();
        }

        /// <summary>
        /// Searches for Bird entities based on a set of filters.
        /// </summary>
        /// <param name="filters">A dictionary containing the filters to apply.</param>
        /// <returns>An enumerable of Bird entities that match the filters.</returns>
        public virtual IEnumerable<Bird> BirdSearch(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Pets
                .Include(p => p.PetOwners)
                .ThenInclude(po => po.Client)
                .Include(p => p.Bookings)
                .AsNoTracking()
                .OfType<Bird>();

            var predicate = PredicateBuilder.New<Bird>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // For each type of filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Bird>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;

                    if (filter.FilterName == "Name")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Bird>(p => p.Name, filter));
                    }

                    else if (filter.FilterName == "Client")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Bird>(p => p.PetOwners.FirstOrDefault().Client.Name, filter));
                    }

                    else if (filter.FilterName == "Owner")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Bird>(p => p.PetOwners.FirstOrDefault().Client.Name, filter));
                    }
                    else if (filter.FilterName == "ID")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Bird>(p => p.ID, filter));
                    }
                    else if (filter.FilterName == "Colour")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Bird>(p => p.Colour, filter));
                    }
                    else if (filter.FilterName == "Species")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Bird>(p => p.Species, filter));
                    }
                }

                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate).ToList();
        }
    }
}
