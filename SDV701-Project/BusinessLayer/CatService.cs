using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing cat entities.
    /// </summary>
    public class CatService : Service, ICatService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public CatService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Retrieves a cat by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the cat.</param>
        /// <returns>The cat model.</returns>
        public CatModel Get(int id)
        {
            var cat = UnitOfWork.PetRepository.Get(id);
            var model = new CatModel();

            //Do the mapping
            _mapper.Map(cat, model);

            return model;
        }

        /// <summary>
        /// Adds a new cat entity.
        /// </summary>
        /// <param name="model">The cat model to add.</param>
        /// <returns>The identifier of the newly added cat.</returns>
        public int Add(CatModel model)
        {
            Validate(model);

            var data = new Cat();

            _mapper.Map(model, data);

            //Add the cat to the repository and save
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
        /// Updates an existing cat entity.
        /// </summary>
        /// <param name="model">The cat model to update.</param>
        /// <returns>The identifier of the updated cat.</returns>
        public int Update(CatModel model)
        {
            Validate(model);

            //Retrieve the cat to update
            var data = UnitOfWork.PetRepository.Get(model.ID);
            if (data == null) throw new Exception("Pet not found");

            //Map the model to the entity
            _mapper.Map(model, data);

            // Update the PetOwners
            var existingOwners = data.PetOwners.Select(po => po.ClientID).ToList();
            var newOwners = model.OwnerIDs.Except(existingOwners).ToList();
            var removedOwners = existingOwners.Except(model.OwnerIDs).ToList();

            foreach (var ownerID in newOwners)
            {
                var petOwner = new PetOwner { Pet = data, ClientID = ownerID };
                UnitOfWork.PetOwnerRepository.Add(petOwner);
            }

            foreach (var ownerID in removedOwners)
            {
                var petOwner = data.PetOwners.First(po => po.ClientID == ownerID);
                UnitOfWork.PetOwnerRepository.Delete(petOwner);
            }

            //Update and save the 
            UnitOfWork.PetRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a cat entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the cat to delete.</param>
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
        /// Retrieves a list of all cats.
        /// </summary>
        /// <returns>A list of cat models.</returns>
        public IList<CatModel> List()
        {
            var Cats = UnitOfWork.PetRepository.List<Cat>();

            var models = new List<CatModel>();

            _mapper.Map(Cats, models);

            return models;
        }

        /// <summary>
        /// Retrieves a list of cats owned by a specific owner.
        /// </summary>
        /// <param name="ownerID">The identifier of the owner.</param>
        /// <returns>A list of cat models.</returns>
        public IList<CatModel> List(int ownerID)
        {
            var Cats = UnitOfWork.PetRepository.List<Cat>(ownerID);

            var models = new List<CatModel>();

            _mapper.Map(Cats, models);

            return models;
        }

        /// <summary>
        /// Searches for cats based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of cat models that match the filters.</returns>
        public IList<CatModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var pets = UnitOfWork.PetRepository.CatSearch(filters);

            var models = new List<CatModel>();

            _mapper.Map(pets, models);

            return models;
        }
    }
}
