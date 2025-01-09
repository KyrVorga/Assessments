using Models;
using SharedLibrary;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with task-related API endpoints.
    /// </summary>
    public class TaskClient : BaseClient, ITaskClient
    {
        private new readonly string _baseUrl = "/api/task";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public TaskClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a task by its identifier.
        /// </summary>
        /// <param name="id">The task's identifier.</param>
        /// <returns>A <see cref="TaskModel"/> representing the task.</returns>
        public async Task<TaskModel> GetAsync(int id)
        {
            return await GetAsync<TaskModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all tasks.
        /// </summary>
        /// <returns>A list of <see cref="TaskModel"/>.</returns>
        public async Task<IList<TaskModel>> ListAsync()
        {
            return await GetAsync<IList<TaskModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new task.
        /// </summary>
        /// <param name="model">The task model to add.</param>
        /// <returns>The ID of the added task.</returns>
        public async Task<int> AddAsync(TaskModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Adds a new task along with its associated schedules.
        /// </summary>
        /// <param name="model">The task model to add.</param>
        /// <param name="scheduleModels">The schedules associated with the task.</param>
        /// <returns>The ID of the added task.</returns>
        public async Task<int> AddAsync(TaskModel model, IEnumerable<ScheduleModel> scheduleModels)
        {
            var taskSchedule = new TaskSchedule { Task = model, Schedules = scheduleModels };
            return await AddAsync($"{_baseUrl}/schedules", taskSchedule);
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="model">The task model to update.</param>
        /// <returns>The ID of the updated task.</returns>
        public async Task<int> UpdateAsync(TaskModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing task along with its associated schedules.
        /// </summary>
        /// <param name="model">The task model to update.</param>
        /// <param name="scheduleModels">The schedules associated with the task.</param>
        /// <returns>The ID of the updated task.</returns>
        public async Task<int> UpdateAsync(TaskModel model, IEnumerable<ScheduleModel> scheduleModels)
        {
            var taskSchedule = new TaskSchedule { Task = model, Schedules = scheduleModels };
            return await UpdateAsync($"{_baseUrl}/schedules", taskSchedule);
        }

        /// <summary>
        /// Deletes a task by its identifier.
        /// </summary>
        /// <param name="id">The task's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for tasks matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="TaskModel"/> matching the search criteria.</returns>
        public async Task<IList<TaskModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<TaskModel>>($"{_baseUrl}/search?", filters);
        }

        /// <summary>
        /// Retrieves timeline events for specified tasks.
        /// </summary>
        /// <param name="taskIds">Optional list of task IDs to filter the timeline events.</param>
        /// <returns>A list of <see cref="TimelineEvent"/> related to the specified tasks.</returns>
        public async Task<IList<TimelineEvent>> GetTimelineEventsAsync(List<int> taskIds = null)
        {
            if (taskIds != null)
            {
                var ids = string.Join(",", taskIds);
                return await GetAsync<IList<TimelineEvent>>($"{_baseUrl}/timeline?taskIds={ids}");
            }
            else
            {
                return await GetAsync<IList<TimelineEvent>>($"{_baseUrl}/timeline");
            }
        }
    }
}
