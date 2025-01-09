using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with trait-related API endpoints.
    /// </summary>
    public class TraitClient : BaseClient, ITraitClient
    {
        private new readonly string _baseUrl = "/api/trait";

        /// <summary>
        /// Initializes a new instance of the <see cref="TraitClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public TraitClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a trait by its identifier.
        /// </summary>
        /// <param name="id">The trait's identifier.</param>
        /// <returns>A <see cref="TraitModel"/> representing the trait.</returns>
        public async Task<TraitModel> GetAsync(int id)
        {
            return await GetAsync<TraitModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all traits.
        /// </summary>
        /// <returns>A list of <see cref="TraitModel"/>.</returns>
        public async Task<IList<TraitModel>> ListAsync()
        {
            return await GetAsync<IList<TraitModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new trait.
        /// </summary>
        /// <param name="model">The trait model to add.</param>
        /// <returns>The ID of the added trait.</returns>
        public async Task<int> AddAsync(TraitModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing trait.
        /// </summary>
        /// <param name="model">The trait model to update.</param>
        /// <returns>The ID of the updated trait.</returns>
        public async Task<int> UpdateAsync(TraitModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a trait by its identifier.
        /// </summary>
        /// <param name="id">The trait's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for traits matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="TraitModel"/> matching the search criteria.</returns>
        public async Task<IList<TraitModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<TraitModel>>($"{_baseUrl}/search?", filters);
        }
    }
}
