using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls.Searches
{
    /// <summary>
    /// Represents a control for searching and displaying task entities.
    /// </summary>
    public partial class TaskSearchControl : SearchControl, ISearchControl
    {
        private ITaskClient _taskClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskSearchControl"/> class.
        /// </summary>
        public TaskSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API clients required for task data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _taskClient = new TaskClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays task entities along with their associated details.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Load the tasks and pets.
            var tasks = await _taskClient.SearchAsync(filters);
            entities = tasks;

            // Display the tasks in the data grid view.
            var taskDisplayList = tasks.Select(task =>
            {
                return new
                {
                    task.ID,
                    task.Name,
                    task.Type,
                    task.Measurement,
                    task.Quantity,
                    task.ScheduleIDs,
                };
            }).ToList();

            dataGridView1.DataSource = taskDisplayList;

            // Set columns to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ScheduleIDs"].Visible = false;

        }
    }
}
