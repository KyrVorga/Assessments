using Models;
using SharedLibrary;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with cat-related API endpoints.
    /// </summary>
    public class CatClient : BaseClient, ICatClient
    {
        private new readonly string _baseUrl = "/api/cat";

        /// <summary>
        /// Initializes a new instance of the <see cref="CatClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public CatClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a cat by its identifier.
        /// </summary>
        /// <param name="id">The cat's identifier.</param>
        /// <returns>A <see cref="CatModel"/> representing the cat.</returns>
        public async Task<CatModel> GetAsync(int id)
        {
            return await GetAsync<CatModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all cats.
        /// </summary>
        /// <returns>A list of <see cref="CatModel"/>.</returns>
        public async Task<IList<CatModel>> ListAsync()
        {
            return await GetAsync<IList<CatModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new cat.
        /// </summary>
        /// <param name="model">The cat model to add.</param>
        /// <returns>The ID of the added cat.</returns>
        public async Task<int> AddAsync(CatModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing cat.
        /// </summary>
        /// <param name="model">The cat model to update.</param>
        /// <returns>The ID of the updated cat.</returns>
        public async Task<int> UpdateAsync(CatModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a cat by its identifier.
        /// </summary>
        /// <param name="id">The cat's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for cats matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="CatModel"/> matching the search criteria.</returns>
        public async Task<IList<CatModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<CatModel>>($"{_baseUrl}/search?", filters);
        }
    }
}
