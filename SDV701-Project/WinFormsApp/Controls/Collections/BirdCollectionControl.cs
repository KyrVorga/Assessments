using Models;

namespace AdminClient.Controls.Collections
{
    public partial class BirdCollectionControl : EntityCollectionControl<BirdModel, BirdSearchForm, BirdForm>
    {
        public BirdCollectionControl()
        {
            InitializeComponent();

            UpdateDisplayText("Birds");

            Entities = new List<BirdModel>();

        }

        protected override void AddEntity()
        {
            // On add, open the Bird search form
            // add the Bird that's returned, to the list of entities

            // Open the search form
            var searchForm = new BirdSearchForm();
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
                MessageBox.Show("Bird already exists in the list.");
                return;
            }

            // Add the selected entity to the list
            if (selectedEntity != null)
            {
                Entities.Add((BirdModel)selectedEntity);
            }
        }

        protected override void UpdateEntity(BirdModel selectedEntity)
        {
            // On update, open the Bird form on the selected entity
            // update the Bird in the list of entities

            // Open the edit form
            var editForm = new BirdForm(selectedEntity);
            var result = editForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var updatedEntity = editForm.Bird;

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
