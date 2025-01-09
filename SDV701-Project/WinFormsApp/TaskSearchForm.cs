namespace AdminClient
{
    public partial class TaskSearchForm : SearchForm, ISearchForm
    {
        public TaskSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Task and lock it
            SetEntitySelector("Task");
            DisableEntitySelector();
        }

        protected override void newButton_Click(object sender, EventArgs e)
        {
            // Create a TaskForm and display to the user
            var taskForm = new TaskForm();
            var result = taskForm.ShowDialog();

            // If the result is bad, return
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the selected entity to the Task
            SetSelectedEntity(taskForm.Task);

            // Update the list to include the new Task
            LoadEntities();
        }
    }
}
