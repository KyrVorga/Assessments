using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with schedule-related API endpoints.
    /// </summary>
    public class ScheduleClient : BaseClient, IScheduleClient
    {
        private new readonly string _baseUrl = "/api/schedule";

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ScheduleClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a schedule by its identifier.
        /// </summary>
        /// <param name="id">The schedule's identifier.</param>
        /// <returns>A <see cref="ScheduleModel"/> representing the schedule.</returns>
        public async Task<ScheduleModel> GetAsync(int id)
        {
            return await GetAsync<ScheduleModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all schedules.
        /// </summary>
        /// <returns>A list of <see cref="ScheduleModel"/>.</returns>
        public async Task<IList<ScheduleModel>> ListAsync()
        {
            return await GetAsync<IList<ScheduleModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new schedule.
        /// </summary>
        /// <param name="model">The schedule model to add.</param>
        /// <returns>The ID of the added schedule.</returns>
        public async Task<int> AddAsync(ScheduleModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing schedule.
        /// </summary>
        /// <param name="model">The schedule model to update.</param>
        /// <returns>The ID of the updated schedule.</returns>
        public async Task<int> UpdateAsync(ScheduleModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a schedule by its identifier.
        /// </summary>
        /// <param name="id">The schedule's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for schedules matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="ScheduleModel"/> matching the search criteria.</returns>
        public async Task<IList<ScheduleModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<ScheduleModel>>($"{_baseUrl}/search?", filters);
        }

        /// <summary>
        /// Retrieves schedules associated with a specific task.
        /// </summary>
        /// <param name="taskID">The task's identifier.</param>
        /// <returns>A list of <see cref="ScheduleModel"/> related to the specified task.</returns>
        public async Task<IList<ScheduleModel>> GetTaskSchedulesAsync(int taskID)
        {
            string path = $"{_baseUrl}/task/{taskID}";
            return await GetAsync<IList<ScheduleModel>>(path: path);
        }
    }
}
