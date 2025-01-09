using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing client entities.
    /// </summary>
    public class ClientService : Service, IClientService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public ClientService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Retrieves a client by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the client.</param>
        /// <returns>The client model.</returns>
        public ClientModel Get(int id)
        {
            //Get the Client
            var Client = UnitOfWork.ClientRepository.Get(id);

            //Create the model to map the Client entity to
            var model = new ClientModel();

            //Do the mapping
            _mapper.Map(Client, model);

            return model;
        }

        /// <summary>
        /// Adds a new client entity.
        /// </summary>
        /// <param name="model">The client model to add.</param>
        /// <returns>The identifier of the newly added client.</returns>
        public int Add(ClientModel model)
        {
            // Validate the Client model
            Validate(model);

            var client = new Client();
            _mapper.Map(model, client);

            // Add the Client to the repository and save
            UnitOfWork.ClientRepository.Add(client);
            UnitOfWork.Save();

            //// Now client.ID contains the ID of the newly added client

            //// Add entries into PetOwners
            //foreach (var petID in model.PetIDs)
            //{
            //    // Ensure here that petID refers to an existing Pet in your database
            //    var petOwner = new PetOwner { ClientID = client.ID, PetID = petID };
            //    UnitOfWork.PetOwnerRepository.Add(petOwner);
            //}

            //// Save the PetOwners
            //UnitOfWork.Save();

            return client.ID;
        }


        /// <summary>
        /// Updates an existing client entity.
        /// </summary>
        /// <param name="model">The client model to update.</param>
        /// <returns>The identifier of the updated client.</returns>
        public int Update(ClientModel model)
        {
            // Validate the Client model
            Validate(model);

            //Retrive the Client to update
            var data = UnitOfWork.ClientRepository.Get(model.ID);

            //Map the model to the entity
            _mapper.Map(model, data);


            // Update the PetOwners by deleting the old ones and adding the new ones
            var petOwners = UnitOfWork.PetOwnerRepository.List().Where(po => po.ClientID == data.ID);
            foreach (var petOwner in petOwners)
            {
                UnitOfWork.PetOwnerRepository.Delete(petOwner);
            }

            //Update and save the Client
            UnitOfWork.ClientRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a client entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the client to delete.</param>
        public void Delete(int id)
        {
            var data = UnitOfWork.PetRepository.Get(id);
            if (data != null)
            {
                foreach (var petOwner in data.PetOwners)
                {
                    UnitOfWork.PetOwnerRepository.Delete(petOwner);
                }
            }


            UnitOfWork.ClientRepository.Delete(id);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Retrieves a list of all clients.
        /// </summary>
        /// <returns>A list of client models.</returns>
        public IList<ClientModel> List()
        {
            var Clients = UnitOfWork.ClientRepository.List();

            //Create the model list
            var models = new List<ClientModel>();

            //AutoMapper maps the classes and added the models to the list
            _mapper.Map(Clients, models);

            return models;
        }

        /// <summary>
        /// Searches for clients based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of client models that match the filters.</returns>
        public IList<ClientModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var Clients = UnitOfWork.ClientRepository.Search(filters);

            //Create the model list
            var models = new List<ClientModel>();

            //AutoMapper maps the classes and added the models to the list
            _mapper.Map(Clients, models);

            return models;
        }
    }
}
