using AdminClient.Controls;
using RestAPIClient;
using SharedLibrary;
using System.Data;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents the main form of the application, providing access to various management features.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ITaskClient _taskClient;
        private readonly IBookingClient _bookingClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _taskClient = new TaskClient(Program.Configuration, new HttpClient());
            _bookingClient = new BookingClient(Program.Configuration, new HttpClient());

            // Get the enums values for the enum filters
            var repetitions = Enum.GetNames(typeof(RepetitionEnum)).ToList();
            var frequencies = Enum.GetNames(typeof(FrequencyEnum)).ToList();

            // Initialize the filter actions
            var filterActions = new Dictionary<string, Action>
            {
                { "Date", () => filtersPanel1.AddFilterControl(new DateRangeFilter("Date", "Date")) },
                { "Room", () => filtersPanel1.AddFilterControl(new NumericFilter("Room Number", "Room")) },
                { "Pet", () => filtersPanel1.AddFilterControl(new TextFilter("Pet Name", "Pet")) }
            };

            filtersPanel1.FilterActions = filterActions;
        }

        /// <summary>
        /// Handles the form's Load event. Fetches and displays a list of timeline events.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Get a list of TimelineEvents
            var taskEvents = await _taskClient.GetTimelineEventsAsync();
            var bookingEvents = await _bookingClient.GetTimelineEventsAsync();

            var timelineEvents = new List<TimelineEvent>();
            timelineEvents.AddRange(taskEvents);
            timelineEvents.AddRange(bookingEvents);

            // Update the list with the TimelineEvents
            UpdateList(timelineEvents);
        }

        /// <summary>
        /// Updates the task list with the provided timeline events.
        /// </summary>
        /// <param name="timelineEvents">The timeline events to display.</param>
        private async void UpdateList(IList<TimelineEvent> timelineEvents)
        {
            taskList.Items.Clear();
            foreach (var timelineEvent in timelineEvents)
            {
                taskList.Items.Add(timelineEvent);
            }
        }

        /// <summary>
        /// Handles the search button click event. Filters and updates the task list based on selected filters.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void searchButton_Click(object sender, EventArgs e)
        {
            var filters = filtersPanel1.GetFilters();

            var timelineEvents = new List<TimelineEvent>();

            // Get the filtered set of tasks
            var tasks = await _taskClient.SearchAsync(filters);

            if (tasks.Count > 0)
            {
                // Get the Ids of the tasks
                var taskIds = tasks.Select(t => t.ID).ToList();

                // Get a list of TimelineEvents using the filtered Ids
                var taskEvents = await _taskClient.GetTimelineEventsAsync(taskIds);

                timelineEvents.AddRange(taskEvents);
            }

            // Get the filtered set of bookings
            var bookings = await _bookingClient.SearchAsync(filters);

            if (bookings.Count > 0)
            {
                // Get the Ids of the bookings
                var bookingIds = bookings.Select(b => b.ID).ToList();

                // Get a list of TimelineEvents using the filtered Ids
                var bookingEvents = await _bookingClient.GetTimelineEventsAsync(bookingIds);

                timelineEvents.AddRange(bookingEvents);
            }



            // Update the list with the filtered TimelineEvents
            UpdateList(timelineEvents);
        }

        /// <summary>
        /// Opens the client management form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void clientsButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.SetEntitySelector("Client");
            manageForm.Show();
        }

        /// <summary>
        /// Opens the booking management form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void bookingsButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.SetEntitySelector("Booking");
            manageForm.Show();
        }

        /// <summary>
        /// Opens the pet management form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PetsButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.SetEntitySelector("Cat");
            manageForm.Show();
        }

        /// <summary>
        /// Opens the room management form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void RoomsButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.SetEntitySelector("Room");
            manageForm.Show();
        }

        /// <summary>
        /// Opens the task management form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void tasksButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.SetEntitySelector("Task");
            manageForm.Show();
        }

        /// <summary>
        /// Opens the veterinarian management form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void veterinarianButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.SetEntitySelector("Veterinarian");
            manageForm.Show();
        }
    }
}
