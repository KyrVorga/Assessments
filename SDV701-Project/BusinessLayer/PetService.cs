using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing pet entities.
    /// </summary>
    public class PetService : Service, IPetService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public PetService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Adds a new pet entity.
        /// </summary>
        /// <param name="model">The pet model to add.</param>
        /// <returns>The identifier of the newly added pet.</returns>
        public int Add(IPetModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a pet entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the pet to delete.</param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a pet by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the pet.</param>
        /// <returns>The pet model.</returns>
        public IPetModel Get(int id)
        {
            var pet = UnitOfWork.PetRepository.Get(id);

            // Check the type of the pet and map accordingly
            if (pet is Cat cat)
            {
                var catModel = new CatModel();
                _mapper.Map(cat, catModel);
                return catModel;
            }
            else if (pet is Bird bird)
            {
                var birdModel = new BirdModel();
                _mapper.Map(bird, birdModel);
                return birdModel;
            }
            else
            {
                // Fallback for any other Pet types
                var petModel = new PetModel();
                _mapper.Map(pet, petModel);
                return petModel;
            }
        }

        /// <summary>
        /// Retrieves a list of all pets.
        /// </summary>
        /// <returns>A list of pet models.</returns>
        public IList<IPetModel> List()
        {
            var pets = UnitOfWork.PetRepository.List();

            var models = new List<IPetModel>();

            _mapper.Map(pets, models);

            return models;
        }

        /// <summary>
        /// Updates an existing pet entity.
        /// </summary>
        /// <param name="model">The pet model to update.</param>
        /// <returns>The identifier of the updated pet.</returns>
        public int Update(IPetModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches for pets based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of pet models that match the filters.</returns>
        public IList<IPetModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var pets = UnitOfWork.PetRepository.Search(filters);

            var models = new List<IPetModel>();

            _mapper.Map(pets, models);

            return models;
        }
    }
}
