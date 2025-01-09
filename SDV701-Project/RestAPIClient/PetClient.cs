using Models;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with pet-related API endpoints.
    /// </summary>
    public class PetClient : BaseClient, IPetClient
    {
        private new readonly string _baseUrl = "/api/pet";

        /// <summary>
        /// Initializes a new instance of the <see cref="PetClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public PetClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Adds a new pet asynchronously.
        /// </summary>
        /// <param name="model">The pet model to add.</param>
        /// <returns>The ID of the added pet.</returns>
        public Task<int> AddAsync(PetModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a pet by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The pet's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a pet by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The pet's identifier.</param>
        /// <returns>A <see cref="PetModel"/> representing the pet.</returns>
        public async Task<PetModel> GetAsync(int id)
        {
            return await GetAsync<PetModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all pets asynchronously.
        /// </summary>
        /// <returns>A list of <see cref="IPetModel"/>.</returns>
        public async Task<IList<IPetModel>> ListAsync()
        {
            return await GetAsync<IList<IPetModel>>(_baseUrl);
        }

        /// <summary>
        /// Searches for pets matching the specified criteria asynchronously.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="PetModel"/> matching the search criteria.</returns>
        public Task<IList<PetModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return new Task<IList<PetModel>>(() => new List<PetModel>());
        }

        /// <summary>
        /// Updates an existing pet asynchronously.
        /// </summary>
        /// <param name="model">The pet model to update.</param>
        /// <returns>The ID of the updated pet.</returns>
        public Task<int> UpdateAsync(PetModel model)
        {
            throw new NotImplementedException();
        }

        Task<IList<PetModel>> IAPIClient<PetModel>.ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
