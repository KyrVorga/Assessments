using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing room entities.
    /// </summary>
    public class RoomService : Service, IRoomService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public RoomService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Retrieves a room by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the room.</param>
        /// <returns>The room model.</returns>
        public RoomModel Get(int id)
        {
            //Get the Room
            var Room = UnitOfWork.RoomRepository.Get(id);

            //Create the model to map the Room entity to
            var model = new RoomModel();

            //Do the mapping
            _mapper.Map(Room, model);

            return model;
        }

        /// <summary>
        /// Adds a new room entity.
        /// </summary>
        /// <param name="model">The room model to add.</param>
        /// <returns>The identifier of the newly added room.</returns>
        public int Add(RoomModel model)
        {
            // Validate the Room model
            Validate(model);

            var data = new Room();

            // Map the model to the data entity
            _mapper.Map(model, data);

            // Add the Room to the repository and save
            UnitOfWork.RoomRepository.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Updates an existing room entity.
        /// </summary>
        /// <param name="model">The room model to update.</param>
        /// <returns>The identifier of the updated room.</returns>
        public int Update(RoomModel model)
        {
            // Validate the Room model
            Validate(model);

            //Retrive the Room to update
            var data = UnitOfWork.RoomRepository.Get(model.ID);

            //Map the model to the enitity
            _mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.RoomRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a room entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the room to delete.</param>
        public void Delete(int id)
        {
            UnitOfWork.RoomRepository.Delete(id);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Retrieves a list of all rooms.
        /// </summary>
        /// <returns>A list of room models.</returns>
        public IList<RoomModel> List()
        {
            var Rooms = UnitOfWork.RoomRepository.List();

            //Create the model list
            var models = new List<RoomModel>();

            //AutoMapper maps the classes and added the models to the list
            _mapper.Map(Rooms, models);

            return models;
        }

        /// <summary>
        /// Searches for rooms based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of room models that match the filters.</returns>
        public IList<RoomModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var Rooms = UnitOfWork.RoomRepository.Search(filters);

            //Create the model list
            var models = new List<RoomModel>();

            //AutoMapper maps the classes and added the models to the list
            _mapper.Map(Rooms, models);

            return models;
        }
    }
}
