using Models;
using SharedLibrary;

namespace RestAPIClient
{
    /// <summary>
    /// Provides client functionality for interacting with booking-related API endpoints.
    /// </summary>
    public class BookingClient : BaseClient, IBookingClient
    {
        private new readonly string _baseUrl = "/api/booking";

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingClient"/> class.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public BookingClient(IAPIConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {
        }

        /// <summary>
        /// Retrieves a booking by its identifier.
        /// </summary>
        /// <param name="id">The booking's identifier.</param>
        /// <returns>A <see cref="BookingModel"/> representing the booking.</returns>
        public async Task<BookingModel> GetAsync(int id)
        {
            return await GetAsync<BookingModel>($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Retrieves a list of all bookings.
        /// </summary>
        /// <returns>A list of <see cref="BookingModel"/>.</returns>
        public async Task<IList<BookingModel>> ListAsync()
        {
            return await GetAsync<IList<BookingModel>>(_baseUrl);
        }

        /// <summary>
        /// Adds a new booking.
        /// </summary>
        /// <param name="model">The booking model to add.</param>
        /// <returns>The ID of the added booking.</returns>
        public async Task<int> AddAsync(BookingModel model)
        {
            return await AddAsync(_baseUrl, model);
        }

        /// <summary>
        /// Updates an existing booking.
        /// </summary>
        /// <param name="model">The booking model to update.</param>
        /// <returns>The ID of the updated booking.</returns>
        public async Task<int> UpdateAsync(BookingModel model)
        {
            return await UpdateAsync(_baseUrl, model);
        }

        /// <summary>
        /// Deletes a booking by its identifier.
        /// </summary>
        /// <param name="id">The booking's identifier.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"{_baseUrl}/{id}");
        }

        /// <summary>
        /// Searches for bookings matching the specified criteria.
        /// </summary>
        /// <param name="filters">The search filters.</param>
        /// <returns>A list of <see cref="BookingModel"/> matching the search criteria.</returns>
        public async Task<IList<BookingModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters)
        {
            return await SearchAsync<IList<BookingModel>>($"{_baseUrl}/search?", filters);
        }

        /// <summary>
        /// Retrieves timeline events for specified bookings.
        /// </summary>
        /// <param name="bookingIds">Optional list of booking IDs to filter the timeline events.</param>
        /// <returns>A list of <see cref="TimelineEvent"/> related to the specified bookings.</returns>
        public async Task<IList<TimelineEvent>> GetTimelineEventsAsync(List<int> bookingIds = null)
        {
            if (bookingIds != null)
            {
                var ids = string.Join(",", bookingIds);
                return await GetAsync<IList<TimelineEvent>>($"{_baseUrl}/timeline?bookingIds={ids}");
            }
            else
            {
                return await GetAsync<IList<TimelineEvent>>($"{_baseUrl}/timeline");
            }
        }
    }
}
