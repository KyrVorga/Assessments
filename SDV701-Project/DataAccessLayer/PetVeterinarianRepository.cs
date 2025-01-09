using DataAccessLayer.Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing PetVeterinarian entities in the database.
    /// </summary>
    public class PetVeterinarianRepository : Repository<PetVeterinarian>, IPetVeterinarianRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetVeterinarianRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PetVeterinarianRepository(ModelContext context) : base(context) { }

        /// <summary>
        /// Retrieves a PetVeterinarian entity based on pet and veterinarian IDs.
        /// </summary>
        /// <param name="petID">The pet's ID.</param>
        /// <param name="veterinarianID">The veterinarian's ID.</param>
        /// <returns>The <see cref="PetVeterinarian"/> entity if found; otherwise, null.</returns>
        public virtual PetVeterinarian Get(int petID, int veterinarianID)
        {
            return All.FirstOrDefault(a => a.PetID == petID && a.VeterinarianID == veterinarianID);
        }

        /// <summary>
        /// Retrieves all PetVeterinarian entities.
        /// </summary>
        /// <returns>A list of <see cref="PetVeterinarian"/> entities.</returns>
        public virtual List<PetVeterinarian> GetAll() { return All.ToList(); }
    }
}