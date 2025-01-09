using Models;
using RestAPIClient;
using SharedLibrary;
using System.Data;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing a task entity.
    /// </summary>
    public partial class TaskForm : Form, IEntityForm
    {

        /// <summary>
        /// Gets the task model associated with this form.
        /// </summary>
        public TaskModel Task { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for task operations.
        /// </summary>
        public IAPIClient<TaskModel> APIClient { get; set; }

        /// <summary>
        /// Gets or sets the schedule client used for schedule operations.
        /// </summary>
        public ScheduleClient ScheduleClient { get; set; }

        private readonly bool isEditMode = false;
        private readonly TaskModel _taskToUpdate;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskForm"/> class for creating a new task.
        /// </summary>
        public TaskForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskForm"/> class for editing an existing task.
        /// </summary>
        /// <param name="task">The task to be edited.</param>
        public TaskForm(TaskModel task) : this()
        {
            APIClient = new TaskClient(Program.Configuration, new HttpClient());
            ScheduleClient = new ScheduleClient(Program.Configuration, new HttpClient());

            // Check if the task has an ID
            if (task.ID != null && task.ID > 0)
            {
                _taskToUpdate = task;

                nameTextBox.Text = task.Name;
                typeComboBox.Text = task.Type;
                measurementComboBox.Text = task.Measurement;
                quantityNumeric.Value = task.Quantity;
                notesTextBox.Text = task.Notes;


                isEditMode = true;
            }
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, creates or updates the task entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Ensure that all require fields have been filled
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please add a name for the task.");
                return;
            }


            var schedules = scheduleCollectionControl1.Entities;

            var task = new TaskModel
            {
                Name = nameTextBox.Text,
                Type = typeComboBox.Text,
                Measurement = measurementComboBox.Text,
                Quantity = (int)quantityNumeric.Value,
                Notes = notesTextBox.Text
            };


            int responseCode;

            // Save the task
            if (isEditMode)
            {
                // Add the ID to the task
                task.ID = _taskToUpdate.ID;


                // Check if the schedules have been modified
                if (scheduleCollectionControl1.ChangesMade)
                {
                    // Get a list of the schedule IDs that are currently in the form
                    var currentIDs = schedules.Select(s => s.ID).ToList();

                    // Delete the schedules that have been removed from the form
                    await DeleteRemovedSchedules(currentIDs);


                    // Update the existing schedules
                    List<ScheduleModel> newSchedules = await UpdateExistingSchedules(schedules);

                    // Save the schedules
                    responseCode = await ((TaskClient)APIClient).UpdateAsync(task, newSchedules);
                }
                else
                {
                    // Update the task
                    responseCode = await APIClient.UpdateAsync(task);
                }
            }
            else
            {

                // Check if the schedules have been modified
                if (scheduleCollectionControl1.ChangesMade)
                {
                    // Save the schedules
                    responseCode = await ((TaskClient)APIClient).AddAsync(task, schedules);
                }
                else
                {
                    // Create the task
                    responseCode = await APIClient.AddAsync(task);
                }
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the task.");
            }
        }

        /// <summary>
        /// Deletes schedules that have been removed from the task.
        /// </summary>
        /// <param name="currentIDs">The list of current schedule IDs associated with the task.</param>
        private async Task DeleteRemovedSchedules(List<int> currentIDs)
        {
            // Get a list of the schedule IDs that were provided to the form
            var previousIDs = _taskToUpdate.ScheduleIDs;

            if (previousIDs != null)
            {
                // Remove the schedules that are no longer in the form
                var schedulesToRemove = previousIDs.Except(currentIDs).ToList();
                foreach (var scheduleID in schedulesToRemove)
                {
                    await ScheduleClient.DeleteAsync(scheduleID);
                }
            }
        }

        /// <summary>
        /// Updates existing schedules and returns new schedules for the task.
        /// </summary>
        /// <param name="schedules">The list of schedules to update.</param>
        /// <returns>A list of new schedules.</returns>
        private async Task<List<ScheduleModel>> UpdateExistingSchedules(IList<ScheduleModel> schedules)
        {
            // Update the existing schedules
            foreach (var schedule in schedules)
            {
                if (schedule.ID > 0)
                {
                    await ScheduleClient.UpdateAsync(schedule);
                }
            }

            // Return the schedules that are new
            return schedules.Where(s => s.ID == 0).ToList();
        }

        /// <summary>
        /// Populates the combo boxes with available options for task type and measurement.
        /// </summary>
        public void PopulateComboBoxes()
        {
            typeComboBox.DataSource = Enum.GetValues(typeof(TaskTypeEnum));
            measurementComboBox.DataSource = Enum.GetValues(typeof(MeasurementEnum));
        }

        /// <summary>
        /// Populates the schedule collection control with schedules associated with the task.
        /// </summary>
        /// <param name="schedules">The schedules to populate.</param>
        public void PopulateSchedules(IEnumerable<ScheduleModel> schedules)
        {
            scheduleCollectionControl1.PopulateList(schedules);
        }

        /// <summary>
        /// Handles the Cancel button click event. Closes the form without saving.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Returns the API client associated with this form.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            return APIClient;
        }

        /// <summary>
        /// Handles the form's Load event. Initializes the form with schedules for the specified task.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void TaskForm_Load(object sender, EventArgs e)
        {
            // Get the task ID
            var taskID = _taskToUpdate?.ID;

            if (taskID == null)
            {
                return;
            }
            // Get the schedules
            var schedules = await ScheduleClient.GetTaskSchedulesAsync((int)taskID);
            PopulateSchedules(schedules);
        }
    }
}
