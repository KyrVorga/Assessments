using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing schedules.
    /// </summary>
    public class ScheduleService : Service, IScheduleService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public ScheduleService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        /// <summary>
        /// Retrieves a schedule by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the schedule.</param>
        /// <returns>The schedule model.</returns>
        public ScheduleModel Get(int id)
        {
            //Get the Schedule
            var schedule = UnitOfWork.ScheduleRepository.Get(id);

            //Create the model to map the Schedule entity to
            var model = new ScheduleModel();

            //Do the mapping
            _mapper.Map(schedule, model);

            return model;
        }

        /// <summary>
        /// Retrieves schedules associated with a specific task.
        /// </summary>
        /// <param name="taskID">The identifier of the task.</param>
        /// <returns>A list of schedule models.</returns>
        public List<ScheduleModel> GetTaskSchedules(int taskID)
        {
            //Get the Schedules
            var schedules = UnitOfWork.ScheduleRepository.GetTaskSchedules(taskID);

            //Create the model to map the Schedule entity to
            var model = new List<ScheduleModel>();

            //Do the mapping
            _mapper.Map(schedules, model);

            return model;
        }

        /// <summary>
        /// Adds a new schedule entity.
        /// </summary>
        /// <param name="model">The schedule model to add.</param>
        /// <returns>The identifier of the newly added schedule.</returns>
        public int Add(ScheduleModel model)
        {
            // Validate the Schedule model
            Validate(model);

            var data = new Schedule();
            _mapper.Map(model, data);

            //Add the Schedule to the repository and save
            UnitOfWork.ScheduleRepository.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Updates an existing schedule entity.
        /// </summary>
        /// <param name="model">The schedule model to update.</param>
        /// <returns>The identifier of the updated schedule.</returns>
        public int Update(ScheduleModel model)
        {
            // Validate the Schedule model
            Validate(model);

            //Retrive the Schedule to update
            var data = UnitOfWork.ScheduleRepository.Get(model.ID);

            //Map the model to the enitity
            _mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.ScheduleRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Deletes a schedule entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the schedule to delete.</param>
        public void Delete(int id)
        {
            //Get the Schedule
            var schedule = UnitOfWork.ScheduleRepository.Get(id);

            //Delete the Schedule
            UnitOfWork.ScheduleRepository.Delete(schedule);
            UnitOfWork.Save();
        }

        public IList<ScheduleModel> List()
        {
            throw new NotImplementedException();
        }

        public IList<ScheduleModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            throw new NotImplementedException();
        }
    }
}
