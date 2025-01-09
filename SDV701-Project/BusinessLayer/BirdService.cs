using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing bird entities.
    /// </summary>
    public class BirdService : Service, IBirdService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirdService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public BirdService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Retrieves a bird by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the bird.</param>
        /// <returns>The bird model.</returns>
        public BirdModel Get(int id)
        {
            var Bird = UnitOfWork.PetRepository.Get(id);

            var model = new BirdModel();

            //Do the mapping
            _mapper.Map(Bird, model);

            return model;
        }

        /// <summary>
        /// Adds a new bird entity.
        /// </summary>
        /// <param name="model">The bird model to add.</param>
        /// <returns>The identifier of the newly added bird.</returns>
        public int Add(BirdModel model)
        {
            // Validate the artist model
            var modelValidator = new ModelValidator();
            if (!modelValidator.Validate(model))
            {
                throw new ModelValidationException($"{nameof(model)} is invalid", modelValidator.Errors);
            }

            var data = new Bird();

            _mapper.Map(model, data);

            //Add the artist to the repository and save
            UnitOfWork.PetRepository.Add(data);
            UnitOfWork.Save();

            foreach (var ownerID in model.OwnerIDs)
            {
                var petOwner = new PetOwner { PetID = data.ID, ClientID = ownerID };
                UnitOfWork.PetOwnerRepository.Add(petOwner);
            }
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Updates an existing bird entity.
        /// </summary>
        /// <param name="model">The bird model to update.</param>
        /// <returns>The identifier of the updated bird.</returns>
        public int Update(BirdModel model)
        {
            // Validate the artist model
            var modelValidator = new ModelValidator();
            if (!modelValidator.Validate(model))
            {
                throw new ModelValidationException($"{nameof(model)} is invalid", modelValidator.Errors);
            }

            //Retrive the artist to update
            var data = UnitOfWork.PetRepository.Get(model.ID);
            if (data == null) throw new Exception("Pet not found");

            //Map the model to the enitity
            _mapper.Map(model, data);

            // Update the PetOwners
            var existingOwners = data.PetOwners.Select(po => po.ClientID).ToList();
            var newOwners = model.OwnerIDs.Except(existingOwners).ToList();
            var removedOwners = existingOwners.Except(model.OwnerIDs).ToList();

            foreach (var ownerId in newOwners)
            {
                var petOwner = new PetOwner { Pet = data, ClientID = ownerId };
                UnitOfWork.PetOwnerRepository.Add(petOwner);
            }

            foreach (var ownerId in removedOwners)
            {
                var petOwner = data.PetOwners.First(po => po.ClientID == ownerId);
                UnitOfWork.PetOwnerRepository.Delete(petOwner);
            }

            //Update and save the 
            UnitOfWork.PetRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a bird entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the bird to delete.</param>
        public void Delete(int id)
        {
            var data = UnitOfWork.PetRepository.Get(id);
            if (data == null) throw new Exception("Pet not found");

            foreach (var petOwner in data.PetOwners)
            {
                UnitOfWork.PetOwnerRepository.Delete(petOwner);
            }

            UnitOfWork.PetRepository.Delete(id);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Retrieves a list of all birds.
        /// </summary>
        /// <returns>A list of bird models.</returns>
        public IList<BirdModel> List()
        {
            var Birds = UnitOfWork.PetRepository.List<Bird>();

            var models = new List<BirdModel>();

            _mapper.Map(Birds, models);

            return models;
        }

        /// <summary>
        /// Retrieves a list of birds owned by a specific owner.
        /// </summary>
        /// <param name="ownerID">The identifier of the owner.</param>
        /// <returns>A list of bird models.</returns>
        public IList<BirdModel> List(int ownerID)
        {
            var Birds = UnitOfWork.PetRepository.List<Bird>(ownerID);

            var models = new List<BirdModel>();

            _mapper.Map(Birds, models);

            return models;
        }

        /// <summary>
        /// Searches for birds based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of bird models that match the filters.</returns>
        public IList<BirdModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var pets = UnitOfWork.PetRepository.BirdSearch(filters);

            var models = new List<BirdModel>();

            _mapper.Map(pets, models);

            return models;
        }
    }
}
