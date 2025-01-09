using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with veterinarian-related API endpoints.
    /// </summary>
    public class VeterinarianClient : BaseClient, IVeterinarianClient
    {
        private new readonly string _baseUrl = "/api/veterinarian";

        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public VeterinarianClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a veterinarian by their identifier.
        /// </summary>
        /// <param name="id">The veterinarian's identifier.</param>
        /// <returns>A <see cref="VeterinarianModel"/> representing the veterinarian.</returns>
        public async Task<VeterinarianModel> GetAsync(int id)
        {
            return await GetAsync<VeterinarianModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all veterinarians.
        /// </summary>
        /// <returns>A list of <see cref="VeterinarianModel"/>.</returns>
        public async Task<IList<VeterinarianModel>> ListAsync()
        {
            return await GetAsync<IList<VeterinarianModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new veterinarian.
        /// </summary>
        /// <param name="model">The veterinarian model to add.</param>
        /// <returns>The ID of the added veterinarian.</returns>
        public async Task<int> AddAsync(VeterinarianModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing veterinarian.
        /// </summary>
        /// <param name="model">The veterinarian model to update.</param>
        /// <returns>The ID of the updated veterinarian.</returns>
        public async Task<int> UpdateAsync(VeterinarianModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a veterinarian by their identifier.
        /// </summary>
        /// <param name="id">The veterinarian's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for veterinarians matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="VeterinarianModel"/> matching the search criteria.</returns>
        public async Task<IList<VeterinarianModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<VeterinarianModel>>($"{_baseUrl}/search?", filters);
        }
    }
}
