using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public partial class Repository<T> where T : class
    {
        protected ModelContext Context { get; private set; }
        public Repository(ModelContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Creates a <see cref="DbSet<T>" /> that can be used to query and save instances of <see cref="DbSet<T>" />.
        /// </summary>
        protected virtual IQueryable<T> All
        {
            get
            {
                return Context.Set<T>();
            }
        }

        /// <summary>
        /// Adds one or many entities to the context.
        /// </summary>
        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Adds one or many entities to the context.
        /// </summary>
        public virtual void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Context.Set<T>().Add(entity);
            }
        }

        /// <summary>
        /// Updates an entity in the context.
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes an entity from the context.
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Returns a list of all entities within the context.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> List()
        {
            return All.ToList();
        }

        protected Expression<Func<T, bool>> GetStringFilterExpression<T>(Func<T, string> selector, FilterCriteria filter)
        {
            var value = filter.Value as string;

            var operation = filter.Operation.ToLower();
            switch (operation)
            {
                case "starts with":
                    return entity => selector(entity).StartsWith(value);
                case "ends with":
                    return entity => selector(entity).EndsWith(value);
                case "contains":
                    return entity => selector(entity).Contains(value);
                case "equals":
                    return entity => selector(entity) == value;
                default:
                    throw new InvalidOperationException("Invalid string operation");

            }
        }

        protected Expression<Func<T, bool>> GetNumericFilterExpression<T>(Func<T, int> selector, FilterCriteria filter)
        {
            var value = int.Parse(filter.Value.ToString());

            var operation = filter.Operation.ToLower();
            switch (operation)
            {
                case "greater than":
                    return entity => selector(entity) > value;
                case "less than":
                    return entity => selector(entity) < value;
                case "equal":
                    return entity => selector(entity) == value;
                case "not equal":
                    return entity => selector(entity) != value;
                case "greater than or equal":
                    return entity => selector(entity) >= value;
                case "less than or equal":
                    return entity => selector(entity) <= value;
                default:
                    throw new InvalidOperationException("Invalid numeric operation");
            }
        }

        protected Expression<Func<T, bool>> GetDateFilterExpression<T>(Func<T, DateTime?> selector, FilterCriteria filter)
        {
            var operation = filter.Operation.ToLower();
            switch (operation)
            {
                case "within range":
                    var dates = filter.Value.ToString().Split('_');
                    DateTime startDate = DateTime.Parse(dates[0]);
                    DateTime endDate = DateTime.Parse(dates[1]);
                    return entity => selector(entity).HasValue && selector(entity).Value >= startDate && selector(entity).Value <= endDate;
                case "outside range":
                    var dates2 = filter.Value.ToString().Split('_');
                    DateTime startDate2 = DateTime.Parse(dates2[0]);
                    DateTime endDate2 = DateTime.Parse(dates2[1]);
                    return entity => !selector(entity).HasValue || selector(entity).Value < startDate2 || selector(entity).Value > endDate2;
                case "before":
                    var valueBefore = DateTime.Parse(filter.Value.ToString());
                    return entity => selector(entity).HasValue && selector(entity).Value < valueBefore;
                case "after":
                    var valueAfter = DateTime.Parse(filter.Value.ToString());
                    return entity => selector(entity).HasValue && selector(entity).Value > valueAfter;
                default:
                    throw new InvalidOperationException("Invalid date operation");
            }
        }

        protected Expression<Func<T, bool>> GetBoolFilterExpression<T>(Func<T, bool> selector, FilterCriteria filter)
        {
            var value = bool.Parse(filter.Value.ToString());
            switch (filter.Operation)
            {
                case "is":
                    return entity => selector(entity) == value;
                case "is not":
                    return entity => selector(entity) != value;
                default:
                    throw new InvalidOperationException("Invalid boolean operation");
            }
        }
    }
}
