using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with bird-related API endpoints.
    /// </summary>
    public class BirdClient : BaseClient, IBirdClient
    {
        private new readonly string _baseUrl = "/api/bird";

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public BirdClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a bird by its identifier.
        /// </summary>
        /// <param name="id">The bird's identifier.</param>
        /// <returns>A <see cref="BirdModel"/> representing the bird.</returns>
        public async Task<BirdModel> GetAsync(int id)
        {
            return await GetAsync<BirdModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all birds.
        /// </summary>
        /// <returns>A list of <see cref="BirdModel"/>.</returns>
        public async Task<IList<BirdModel>> ListAsync()
        {
            return await GetAsync<IList<BirdModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new bird.
        /// </summary>
        /// <param name="model">The bird model to add.</param>
        /// <returns>The ID of the added bird.</returns>
        public async Task<int> AddAsync(BirdModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing bird.
        /// </summary>
        /// <param name="model">The bird model to update.</param>
        /// <returns>The ID of the updated bird.</returns>
        public async Task<int> UpdateAsync(BirdModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a bird by its identifier.
        /// </summary>
        /// <param name="id">The bird's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for birds matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="BirdModel"/> matching the search criteria.</returns>
        public async Task<IList<BirdModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<BirdModel>>($"{_baseUrl}/search?", filters);
        }
    }
}
