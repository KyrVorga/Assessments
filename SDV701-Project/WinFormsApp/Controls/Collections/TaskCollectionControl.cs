using Models;

namespace AdminClient.Controls.Collections
{
    public partial class TaskCollectionControl : EntityCollectionControl<TaskModel, TaskSearchForm, TaskForm>
    {
        public TaskCollectionControl()
        {
            InitializeComponent();

            UpdateDisplayText("Tasks");

            Entities = new List<TaskModel>();

        }

        protected override void AddEntity()
        {
            // On add, open the Task search form
            // add the task that's returned, to the list of entities

            // Open the search form
            var searchForm = new TaskSearchForm();
            var result = searchForm.ShowDialog();

            // If the result is OK, add the selected entity to the list
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Get the selected entity from the search form
            IEntityModel selectedEntity = (IEntityModel)searchForm.GetSelectedEntity();

            // Check if the selected entity is already in the list
            if (selectedEntity != null && Entities.Any(e => e.ID == selectedEntity.ID))
            {
                MessageBox.Show("Task already exists in the list.");
                return;
            }

            // Add the selected entity to the list
            if (selectedEntity != null)
            {
                Entities.Add((TaskModel)selectedEntity);
            }
        }

        protected override void UpdateEntity(TaskModel selectedEntity)
        {
            // On update, open the Task form on the selected entity
            // update the task in the list of entities

            // Open the edit form
            var editForm = new TaskForm(selectedEntity);
            var result = editForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var updatedEntity = editForm.Task;

            // Find the entity in the list and update it
            var entity = Entities.Single(e => e.ID == updatedEntity.ID);

            if (entity != null)
            {
                Entities.Remove(entity);
                Entities.Add(updatedEntity);
            }
        }
    }
}
