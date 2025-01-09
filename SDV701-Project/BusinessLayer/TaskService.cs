 using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;
using SharedLibrary;

namespace BusinessLayer
{
    /// <summary>
    /// Provides services for managing tasks.
    /// </summary>
    public class TaskService : Service, ITaskService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for entity mapping.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        public TaskService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        /// <summary>
        /// Retrieves a task by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the task.</param>
        /// <returns>The task model.</returns>
        public TaskModel Get(int id)
        {
            //Get the Task
            var task = UnitOfWork.TaskRepository.Get(id);

            //Create the model to map the Task entity to
            var model = new TaskModel();

            //Do the mapping
            _mapper.Map(task, model);

            return model;
        }

        /// <summary>
        /// Adds a new task entity.
        /// </summary>
        /// <param name="model">The task model to add.</param>
        /// <returns>The identifier of the newly added task.</returns>
        public int Add(TaskModel model)
        {
            // Validate the Task model
            Validate(model);

            var data = new DataAccessLayer.Models.Task();
            _mapper.Map(model, data);

            //Add the Task to the repository and save
            UnitOfWork.TaskRepository.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Adds a new task entity along with associated schedules.
        /// </summary>
        /// <param name="taskModel">The task model to add.</param>
        /// <param name="schedulesModels">The collection of schedule models associated with the task.</param>
        /// <returns>The identifier of the newly added task.</returns>
        public int Add(TaskModel taskModel, IEnumerable<ScheduleModel> schedulesModels)
        {
            // Validate the Task model
            Validate(taskModel);

            // validate the schedules
            foreach (var schedule in schedulesModels)
            {
                Validate(schedule);
            }

            // Map the TaskModel to the DL Task
            var task = new DataAccessLayer.Models.Task();
            _mapper.Map(taskModel, task);

            // Map the ScheduleModels to the DL Schedules
            var schedules = new List<Schedule>();

            foreach (var scheduleModel in schedulesModels)
            {
                var schedule = new Schedule();
                _mapper.Map(scheduleModel, schedule);
                schedules.Add(schedule);
            }


            //Add the Task to the repository and save
            UnitOfWork.TaskRepository.Add(task, schedules);
            UnitOfWork.Save();

            return task.ID;
        }

        /// <summary>
        /// Updates an existing task entity.
        /// </summary>
        /// <param name="model">The task model to update.</param>
        /// <returns>The identifier of the updated task.</returns>
        public int Update(TaskModel model)
        {
            // Validate the Task model
            Validate(model);

            //Retrieve the Task to update
            var data = UnitOfWork.TaskRepository.Get(model.ID);

            //Map the model to the entity
            _mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.TaskRepository.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }

        /// <summary>
        /// Updates an existing task entity along with associated schedules.
        /// </summary>
        /// <param name="model">The task model to update.</param>
        /// <param name="schedulesModels">The collection of schedule models to associate with the task.</param>
        /// <returns>The identifier of the updated task.</returns>
        public int Update(TaskModel model, IEnumerable<ScheduleModel> schedulesModels)
        {
            // Validate the Task model
            Validate(model);

            // validate the schedules
            foreach (var schedule in schedulesModels)
            {
                Validate(schedule);
            }

            // Retrieve the Task to update
            var task = UnitOfWork.TaskRepository.Get(model.ID);
            _mapper.Map(model, task);

            // Map and add new schedules
            var schedulesToAdd = new List<Schedule>();
            foreach (var scheduleModel in schedulesModels)
            {
                var schedule = new Schedule();
                _mapper.Map(scheduleModel, schedule);
                schedulesToAdd.Add(schedule);
            }

            // Update the task with new and updated schedules
            UnitOfWork.TaskRepository.Update(task, schedulesToAdd);
            UnitOfWork.Save();

            return task.ID;
        }

        /// <summary>
        /// Deletes a task entity by its identifier.
        /// </summary>
        /// <param name="ID">The identifier of the task to delete.</param>
        public void Delete(int ID)
        {
            // Get the Task
            var task = UnitOfWork.TaskRepository.Get(ID);
            if (task == null)
            {
                return;
            }
            if (task.Schedules != null)
            {
                // Delete the Schedules
                foreach (var schedule in task.Schedules)
                {
                    UnitOfWork.ScheduleRepository.Delete(schedule);
                }
            }

            //Delete the Task
            UnitOfWork.TaskRepository.Delete(task);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Retrieves a list of all tasks.
        /// </summary>
        /// <returns>A list of task models.</returns>
        public IList<TaskModel> List()
        {
            //Get the list of Tasks
            var tasks = UnitOfWork.TaskRepository.GetAll();

            //Create a list of TaskModels
            var models = new List<TaskModel>();

            //Do the mapping
            _mapper.Map(tasks, models);

            return models;
        }

        /// <summary>
        /// Searches for tasks based on specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply to the search.</param>
        /// <returns>A list of task models that match the filters.</returns>
        public IList<TaskModel> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            //Search for the Tasks
            var tasks = UnitOfWork.TaskRepository.Search(filters);

            //Create a list of TaskModels
            var models = new List<TaskModel>();

            //Do the mapping
            _mapper.Map(tasks, models);

            return models;
        }

        /// <summary>
        /// Retrieves a list of timeline events for specified tasks, or all tasks.
        /// </summary>
        /// <param name="taskIds">Optional; The identifiers of the tasks to retrieve timeline events for.</param>
        /// <returns>A list of timeline events.</returns>
        public IList<TimelineEvent> GetTimelineEvents(List<int> taskIds = null)
        {
            //Get the list of TimelineEvents
            var timelineEvents = UnitOfWork.TaskRepository.GetTimelineEvents(taskIds);

            return timelineEvents;
        }
    }
}
