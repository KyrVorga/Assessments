using Newtonsoft.Json;
using System.Text;

namespace RestAPIClient
{
    /// <summary>
    /// Provides a base implementation for REST API clients.
    /// </summary>
    public abstract class BaseClient
    {
        protected string _baseUrl;
        private readonly IAPIConfiguration _configuration;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Gets the API configuration.
        /// </summary>
        public IAPIConfiguration Configuration { get => _configuration; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public BaseClient(IAPIConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(configuration.Timeout);
            _httpClient.BaseAddress = new Uri(configuration.Url);
        }

        /// <summary>
        /// Performs a GET request asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the response object.</typeparam>
        /// <param name="path">The request path.</param>
        /// <returns>The deserialized response object.</returns>
        protected async Task<T> GetAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    NullValueHandling = NullValueHandling.Ignore
                };
                return JsonConvert.DeserializeObject<T>(content, settings);
            }
            else
            {
                throw new Exception(content);
            }
        }

        /// <summary>
        /// Performs an ADD operation asynchronously.
        /// </summary>
        /// <param name="path">The request path.</param>
        /// <param name="model">The model to add.</param>
        /// <returns>The ID of the added model.</returns>
        protected async Task<int> AddAsync(string path, object model)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(model, settings);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(path, jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Convert.ToInt32(content);
            }
            else
            {
                throw new Exception(content);
            }
        }

        /// <summary>
        /// Performs an UPDATE operation asynchronously.
        /// </summary>
        /// <param name="path">The request path.</param>
        /// <param name="model">The model to update.</param>
        /// <returns>The ID of the updated model.</returns>
        protected async Task<int> UpdateAsync(string path, object model)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(model, settings);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(path, jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Convert.ToInt32(content);
            }
            else
            {
                throw new Exception(content);
            }
        }

        /// <summary>
        /// Performs a DELETE operation asynchronously.
        /// </summary>
        /// <param name="path">The request path.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        protected async Task<bool> DeleteAsync(string path)
        {
            var deleteResponse = await _httpClient.DeleteAsync(path);

            return deleteResponse.IsSuccessStatusCode;
        }

        /// <summary>
        /// Performs a SEARCH operation asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the response object.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="filters">The search filters.</param>
        /// <returns>The deserialized response object.</returns>
        protected virtual async Task<T> SearchAsync<T>(string path, Dictionary<string, List<FilterCriteria>> filters)
        {
            var sb = new StringBuilder(path);

            // Check if filters are present
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    foreach (var value in filter.Value)
                    {
                        sb.Append($"{value.ToString()}&");
                    }
                }
            }

            // Remove the trailing '&' if present
            var requestUrl = sb.ToString().TrimEnd('&');

            return await GetAsync<T>(requestUrl);
        }
    }
}
