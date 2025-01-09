using DataAccessLayer.Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing Schedule entities in the database.
    /// </summary>
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ScheduleRepository(ModelContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves a Schedule entity by its ID.
        /// </summary>
        /// <param name="scheduleID">The ID of the Schedule.</param>
        /// <returns>The <see cref="Schedule"/> entity if found; otherwise, null.</returns>
        public virtual Schedule Get(int scheduleID)
        {
            return All.FirstOrDefault(a => a.ID == scheduleID);
        }

        /// <summary>
        /// Retrieves all Schedule entities.
        /// </summary>
        /// <returns>A list of <see cref="Schedule"/> entities.</returns>
        public virtual List<Schedule> GetAll() { return All.ToList(); }

        /// <summary>
        /// Retrieves all Schedule entities associated with a specific Task.
        /// </summary>
        /// <param name="taskID">The ID of the Task.</param>
        /// <returns>A list of <see cref="Schedule"/> entities associated with the specified Task.</returns>
        public object GetTaskSchedules(int taskID)
        {
            return All.Where(a => a.Task.ID == taskID).ToList();
        }
    }
}
