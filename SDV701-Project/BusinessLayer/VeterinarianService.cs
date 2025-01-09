using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing veterinarian entities.
    /// </summary>
    public class VeterinarianService : Service, IVeterinarianService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public VeterinarianService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public VeterinarianModel Get(int id)
        {
            //Get the Veterinarian
            var veterinarian = UnitOfWork.VeterinarianRepository.Get(id);

            //Create the model to map the Veterinarian entity to
            var model = new VeterinarianModel();

            //Do the mapping
            _mapper.Map(veterinarian, model);

            return model;
        }

        /// <summary>
        /// Adds a new veterinarian entity.
        /// </summary>
        /// <param name="model">The veterinarian model to add.</param>
        /// <returns>The identifier of the newly added veterinarian.</returns>
        public int Add(VeterinarianModel model)
        {
            // Validate the Veterinarian model
            Validate(model);

            var data = new Veterinarian();

            _mapper.Map(model, data);

            //Add the Veterinarian to the repository and save
            UnitOfWork.VeterinarianRepository.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Updates an existing veterinarian entity.
        /// </summary>
        /// <param name="model">The veterinarian model to update.</param>
        /// <returns>The identifier of the updated veterinarian.</returns>
        public int Update(VeterinarianModel model)
        {
            // Validate the Veterinarian model
            Validate(model);

            //Retrive the Veterinarian to update
            var data = UnitOfWork.VeterinarianRepository.Get(model.ID);

            //Map the model to the enitity
            _mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.VeterinarianRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a veterinarian entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the veterinarian to delete.</param>
        public void Delete(int id)
        {
            //Get the Veterinarian to delete
            var veterinarian = UnitOfWork.VeterinarianRepository.Get(id);

            //Delete the Veterinarian
            UnitOfWork.VeterinarianRepository.Delete(veterinarian);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Retrieves a list of all veterinarians.
        /// </summary>
        /// <returns>A list of veterinarian models.</returns>
        public IList<VeterinarianModel> List()
        {
            //Get the Veterinarians
            var veterinarians = UnitOfWork.VeterinarianRepository.List();

            //Create the model to map the Veterinarian entity to
            var model = new List<VeterinarianModel>();

            //Do the mapping
            _mapper.Map(veterinarians, model);

            return model;
        }

        /// <summary>
        /// Searches for traits based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of trait models that match the filters.</returns>
        public IList<VeterinarianModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            //Get the Veterinarians
            var veterinarians = UnitOfWork.VeterinarianRepository.Search(filters);

            //Create the model to map the Veterinarian entity to
            var model = new List<VeterinarianModel>();

            //Do the mapping
            _mapper.Map(veterinarians, model);

            return model;
        }
    }
}
