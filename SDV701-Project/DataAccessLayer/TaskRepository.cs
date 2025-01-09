using DataAccessLayer.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository for managing Task entities in the database.
    /// </summary>
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public TaskRepository(ModelContext context) : base(context) { }

        /// <summary>
        /// Retrieves a Task entity by its ID.
        /// </summary>
        /// <param name="taskID">The ID of the Task.</param>
        /// <returns>The <see cref="Models.Task"/> entity if found; otherwise, null.</returns>
        public virtual Models.Task Get(int taskID)
        {
            return All.FirstOrDefault(a => a.ID == taskID);
        }

        /// <summary>
        /// Retrieves all Task entities.
        /// </summary>
        /// <returns>A list of <see cref="Models.Task"/> entities.</returns>
        public virtual List<Models.Task> GetAll()
        {
            return All.Include(t => t.Schedules).ToList();
        }

        /// <summary>
        /// Adds a new Task entity and its associated Schedules to the database.
        /// </summary>
        /// <param name="task">The Task entity to add.</param>
        /// <param name="schedules">The collection of Schedule entities associated with the Task.</param>
        public virtual void Add(Models.Task task, IEnumerable<Schedule> schedules)
        {
            // Add the task first
            Add(task);

            // Assign the task to each schedule
            foreach (var schedule in schedules)
            {
                schedule.Task = task;
            }

            // Add all the schedules
            Context.Set<Schedule>().AddRange(schedules);

            // Add the schedules to the task
            task.Schedules = (ICollection<Schedule>?)schedules;

            // Save the changes
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates an existing Task entity and its associated Schedules in the database.
        /// </summary>
        /// <param name="task">The Task entity to update.</param>
        /// <param name="schedules">The collection of Schedule entities associated with the Task.</param>
        public virtual void Update(Models.Task task, IEnumerable<Schedule> schedules)
        {
            // Update the task
            Update(task);

            // Assign the task to each schedule
            foreach (var schedule in schedules)
            {
                schedule.Task = task;
            }

            // Add all the schedules
            Context.Set<Schedule>().AddRange(schedules);
        }

        /// <summary>
        /// Searches for Task entities based on a set of filters.
        /// </summary>
        /// <param name="filters">A dictionary containing the filters to apply.</param>
        /// <returns>An enumerable of <see cref="Models.Task"/> entities that match the filters.</returns>
        public virtual IEnumerable<Models.Task> Search(Dictionary<string, List<FilterCriteria>> filters)
        {
            var result = Context.Tasks.AsQueryable();

            var predicate = PredicateBuilder.New<Models.Task>(true);

            // If there are no filters, return all
            if (filters.Count == 0)
            {
                return result.AsEnumerable().Where(predicate).ToList();
            }

            // Loop through each filter
            foreach (var key in filters.Keys)
            {
                var innerPredicate = PredicateBuilder.New<Models.Task>(false);

                foreach (var filter in filters[key])
                {
                    var operation = filter.Operation.ToLower();
                    var value = filter.Value;
                    var filterName = filter.FilterName.ToLower();

                    if (filterName == "Name")
                    {
                        innerPredicate = innerPredicate.Or(GetStringFilterExpression<Models.Task>(t => t.Name, filter));
                    }
                    else if (filterName == "ID")
                    {
                        innerPredicate = innerPredicate.Or(GetNumericFilterExpression<Models.Task>(t => t.ID, filter));
                    }
                }

                predicate = predicate.And(innerPredicate);
            }

            return result.AsEnumerable().Where(predicate).ToList();
        }

        /// <summary>
        /// Retrieves a list of TimelineEvent objects for a specified list of Task IDs.
        /// </summary>
        /// <param name="taskIds">An optional list of Task IDs to filter the events by.</param>
        /// <returns>A list of <see cref="TimelineEvent"/> objects.</returns>
        public IList<TimelineEvent> GetTimelineEvents(List<int> taskIds = null)
        {
            var timelineEvents = new List<TimelineEvent>();

            // Get all of the tasks and extra data
            IQueryable<Models.Task> tasksQuery = Context.Tasks
                .Include(t => t.Schedules)
                .Include(t => t.Pet);

            // If a list of IDs is provided, filter the tasks
            if (taskIds != null && taskIds.Count > 0)
            {
                tasksQuery = tasksQuery.Where(t => taskIds.Contains(t.ID));
            }

            var tasks = tasksQuery.ToList();

            foreach (var task in tasks)
            {
                var timelineEvent = new TimelineEvent
                {
                    Type = task.Type,
                    EventName = task.Name,
                };

                if (task.Pet != null)
                {
                    timelineEvent.PetName = task.Pet.Name;
                }
                if (task.Schedules == null)
                {
                    return timelineEvents;
                }

                foreach (var schedule in task.Schedules)
                {
                    timelineEvent.EventTime = DateTime.Parse(schedule.Time);
                    timelineEvent.Time = schedule.Time;

                    switch (schedule.Type)
                    {
                        case "Daily":
                            if (schedule.EndAfter.HasValue)
                            {
                                timelineEvent.EndAfter = schedule.EndAfter;
                            }
                            else if (schedule.EndBefore.HasValue)
                            {
                                timelineEvent.EndBefore = schedule.EndBefore;
                            }
                            break;
                        case "Weekly":
                            if (schedule.DaysOfWeek.HasValue)
                            {
                                timelineEvent.DaysOfWeek = schedule.DaysOfWeek;
                            }
                            if (schedule.EndAfter.HasValue)
                            {
                                timelineEvent.EndAfter = schedule.EndAfter;
                            }
                            else if (schedule.EndBefore.HasValue)
                            {
                                timelineEvent.EndBefore = schedule.EndBefore;
                            }
                            break;
                        case "CustomWeekly":
                            if (schedule.WeekInterval.HasValue)
                            {
                                timelineEvent.WeekInterval = schedule.WeekInterval;
                            }
                            if (schedule.DaysOfWeek.HasValue)
                            {
                                timelineEvent.DaysOfWeek = schedule.DaysOfWeek;
                            }
                            if (schedule.EndAfter.HasValue)
                            {
                                timelineEvent.EndAfter = schedule.EndAfter;
                            }
                            else if (schedule.EndBefore.HasValue)
                            {
                                timelineEvent.EndBefore = schedule.EndBefore;
                            }
                            break;
                        case "Monthly":
                            if (schedule.MonthDays != null)
                            {
                                timelineEvent.MonthDays = schedule.MonthDays;
                            }
                            if (schedule.EndAfter.HasValue)
                            {
                                timelineEvent.EndAfter = schedule.EndAfter;
                            }
                            else if (schedule.EndBefore.HasValue)
                            {
                                timelineEvent.EndBefore = schedule.EndBefore;
                            }
                            break;
                    }

                    timelineEvents.Add(timelineEvent);
                }
            }

            return timelineEvents;
        }
    }
}
