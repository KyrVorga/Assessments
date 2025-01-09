using DataAccessLayer.Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing PetOwner entities in the database.
    /// </summary>
    public class PetOwnerRepository : Repository<PetOwner>, IPetOwnerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetOwnerRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PetOwnerRepository(ModelContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves a PetOwner entity based on client and pet IDs.
        /// </summary>
        /// <param name="clientID">The client's ID.</param>
        /// <param name="petID">The pet's ID.</param>
        /// <returns>The <see cref="PetOwner"/> entity if found; otherwise, null.</returns>
        public virtual PetOwner Get(int clientID, int petID)
        {
            return All.FirstOrDefault(a => a.ClientID == clientID && a.PetID == petID);
        }

        /// <summary>
        /// Retrieves all PetOwner entities.
        /// </summary>
        /// <returns>A list of <see cref="PetOwner"/> entities.</returns>
        public virtual List<PetOwner> GetAll()
        {
            return All.ToList();
        }

        /// <summary>
        /// Deletes a PetOwner entity based on client and pet IDs.
        /// </summary>
        /// <param name="clientID">The client's ID.</param>
        /// <param name="petID">The pet's ID.</param>
        public virtual void Delete(int clientID, int petID)
        {
            var entity = Get(clientID, petID);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// Deletes all PetOwner entities associated with a given client ID.
        /// </summary>
        /// <param name="clientID">The client's ID.</param>
        public virtual void DeleteOwner(int clientID)
        {
            var entities = All.Where(a => a.ClientID == clientID);
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    Delete(entity);
                }
            }
        }

        /// <summary>
        /// Deletes all PetOwner entities associated with a given pet ID.
        /// </summary>
        /// <param name="petID">The pet's ID.</param>
        public virtual void DeletePet(int petID)
        {
            var entities = All.Where(a => a.PetID == petID);
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    Delete(entity);
                }
            }
        }
    }
}
