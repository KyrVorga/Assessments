using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with room-related API endpoints.
    /// </summary>
    public class RoomClient : BaseClient, IRoomClient
    {
        private new readonly string _baseUrl = "/api/room";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public RoomClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a room by its identifier.
        /// </summary>
        /// <param name="id">The room's identifier.</param>
        /// <returns>A <see cref="RoomModel"/> representing the room.</returns>
        public async Task<RoomModel> GetAsync(int id)
        {
            return await GetAsync<RoomModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all rooms.
        /// </summary>
        /// <returns>A list of <see cref="RoomModel"/>.</returns>
        public async Task<IList<RoomModel>> ListAsync()
        {
            return await GetAsync<IList<RoomModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new room.
        /// </summary>
        /// <param name="model">The room model to add.</param>
        /// <returns>The ID of the added room.</returns>
        public async Task<int> AddAsync(RoomModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing room.
        /// </summary>
        /// <param name="model">The room model to update.</param>
        /// <returns>The ID of the updated room.</returns>
        public async Task<int> UpdateAsync(RoomModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a room by its identifier.
        /// </summary>
        /// <param name="id">The room's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for rooms matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="RoomModel"/> matching the search criteria.</returns>
        public async Task<IList<RoomModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<RoomModel>>($"{_baseUrl}/search?", filters);
        }
    }
}
