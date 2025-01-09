using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with client-related API endpoints.
    /// </summary>
    public class ClientClient : BaseClient, IClientClient
    {
        private new readonly string _baseUrl = "/api/client";

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ClientClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a client by its identifier.
        /// </summary>
        /// <param name="id">The client's identifier.</param>
        /// <returns>A <see cref="ClientModel"/> representing the client.</returns>
        public async Task<ClientModel> GetAsync(int id)
        {
            return await GetAsync<ClientModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all clients.
        /// </summary>
        /// <returns>A list of <see cref="ClientModel"/>.</returns>
        public async Task<IList<ClientModel>> ListAsync()
        {
            return await GetAsync<IList<ClientModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new client.
        /// </summary>
        /// <param name="model">The client model to add.</param>
        /// <returns>The ID of the added client.</returns>
        public async Task<int> AddAsync(ClientModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="model">The client model to update.</param>
        /// <returns>The ID of the updated client.</returns>
        public async Task<int> UpdateAsync(ClientModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a client by its identifier.
        /// </summary>
        /// <param name="id">The client's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for clients matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="ClientModel"/> matching the search criteria.</returns>
        public async Task<IList<ClientModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<ClientModel>>($"{_baseUrl}/search?", filters);
        }
    }
}
