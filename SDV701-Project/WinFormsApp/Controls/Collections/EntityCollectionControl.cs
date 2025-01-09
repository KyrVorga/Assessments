using Models;

namespace AdminClient.Controls.Collections
{
    public partial class EntityCollectionControl<TModel, TForm, TEditForm> : UserControl
        where TModel : IEntityModel
        where TForm : Form, ISearchForm
        where TEditForm : Form, IEntityForm
    {
        public IList<TModel> Entities { get; protected set; }
        protected TForm _entityForm;
        protected TEditForm _entityEditForm;
        public bool ChangesMade { get; protected set; }

        public EntityCollectionControl()
        {
            InitializeComponent();
        }

        public void UpdateDisplayText(string displayText)
        {
            label1.Text = displayText;
        }
        protected virtual void addButton_Click(object sender, EventArgs e)
        {
            ChangesMade = true;


            // Add the item to the list
            AddEntity();

            // Update the list
            UpdateEntityList();
        }

        protected virtual void removeButton_Click(object sender, EventArgs e)
        {
            ChangesMade = true;

            // Get the selected item
            var selectedEntity = (TModel)listBox1.SelectedItem;

            // Ensure an item is selected
            if (selectedEntity == null)
            {
                // Open a message box
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RemoveEntity(selectedEntity);

            // Update the list
            UpdateEntityList();
        }

        protected virtual void editButton_Click(object sender, EventArgs e)
        {
            ChangesMade = true;

            // Get the selected item
            var selectedEntity = (TModel)listBox1.SelectedItem;

            // Ensure an item is selected
            if (selectedEntity == null)
            {
                // Open a message box
                MessageBox.Show("Please select an item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the entity
            UpdateEntity(selectedEntity);

            // Update the list
            UpdateEntityList();
        }

        protected void UpdateEntityList()
        {
            listBox1.Items.Clear();
            foreach (var schedule in Entities)
            {
                listBox1.Items.Add(schedule);
            }
        }

        public void PopulateList(IEnumerable<TModel> entities)
        {
            Entities = entities.ToList();
            UpdateEntityList();
        }

        protected virtual void AddEntity()
        {
        }

        protected virtual void UpdateEntity(TModel selectedEntity)
        {
        }

        protected virtual void RemoveEntity(TModel selectedEntity)
        {
            // Remove the item from the list
            Entities.Remove(selectedEntity);
            listBox1.Items.Remove(selectedEntity);
        }
    }
}
