using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class TraitRepository : Repository<Trait>, ITraitRepository
    {
        public TraitRepository(ModelContext context) : base(context)
        {
        }

        public virtual Trait Get(int id)
        {
            return All.FirstOrDefault(a => a.ID == id);
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
    }
}
