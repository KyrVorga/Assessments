using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;
using SharedLibrary;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing booking entities.
    /// </summary>
    public class BookingService : Service, IBookingService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public BookingService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Retrieves a booking by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the booking.</param>
        /// <returns>The booking model.</returns>
        public BookingModel Get(int id)
        {
            //Get the Booking
            var Booking = UnitOfWork.BookingRepository.Get(id);

            //Create the model to map the Booking entity to
            var model = new BookingModel();

            //Do the mapping
            _mapper.Map(Booking, model);

            return model;
        }

        /// <summary>
        /// Adds a new booking entity.
        /// </summary>
        /// <param name="model">The booking model to add.</param>
        /// <returns>The identifier of the newly added booking.</returns>
        public int Add(BookingModel model)
        {
            // Validate the Booking model
            Validate(model);

            var data = new Booking();

            _mapper.Map(model, data);

            //Add the Booking to the repository and save
            UnitOfWork.BookingRepository.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Updates an existing booking entity.
        /// </summary>
        /// <param name="model">The booking model to update.</param>
        /// <returns>The identifier of the updated booking.</returns>
        public int Update(BookingModel model)
        {
            // Validate the Booking model
            Validate(model);

            //Retrive the Booking to update
            var data = UnitOfWork.BookingRepository.Get(model.ID);

            //Map the model to the entity
            _mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.BookingRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a booking entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the booking to delete.</param>
        public void Delete(int id)
        {
            UnitOfWork.BookingRepository.Delete(id);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Retrieves a list of all bookings.
        /// </summary>
        /// <returns>A list of booking models.</returns>
        public IList<BookingModel> List()
        {
            var Bookings = UnitOfWork.BookingRepository.List();

            //Create the model list
            var models = new List<BookingModel>();

            //AutoMapper maps the classes and added the models to the list
            _mapper.Map(Bookings, models);

            return models;
        }

        /// <summary>
        /// Searches for bookings based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of booking models that match the filters.</returns>
        public IList<BookingModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var Bookings = UnitOfWork.BookingRepository.Search(filters);

            //Create the model list
            var models = new List<BookingModel>();

            //AutoMapper maps the classes and added the models to the list
            _mapper.Map(Bookings, models);

            return models;
        }

        /// <summary>
        /// Retrieves a list of timeline events for specified bookings, or all bookings.
        /// </summary>
        /// <param name="bookingIds">Optional; The identifiers of the bookings to retrieve timeline events for.</param>
        /// <returns>A list of timeline events.</returns>
        public IList<TimelineEvent> GetTimelineEvents(List<int> bookingIds = null)
        {
            //Get the list of TimelineEvents
            var timelineEvents = UnitOfWork.BookingRepository.GetTimelineEvents(bookingIds);

            return timelineEvents;
        }
    }
}
