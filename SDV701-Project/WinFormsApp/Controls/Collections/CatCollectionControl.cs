using Models;

namespace AdminClient.Controls.Collections
{
    public partial class CatCollectionControl : EntityCollectionControl<CatModel, CatSearchForm, CatForm>
    {
        public CatCollectionControl()
        {
            InitializeComponent();

            UpdateDisplayText("Cats");

            Entities = new List<CatModel>();

        }

        protected override void AddEntity()
        {
            // On add, open the Cat search form
            // add the cat that's returned, to the list of entities

            // Open the search form
            var searchForm = new CatSearchForm();
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
                MessageBox.Show("Cat already exists in the list.");
                return;
            }

            // Add the selected entity to the list
            if (selectedEntity != null)
            {
                Entities.Add((CatModel)selectedEntity);
            }
        }

        protected override void UpdateEntity(CatModel selectedEntity)
        {
            // On update, open the Cat form on the selected entity
            // update the cat in the list of entities

            // Open the edit form
            var editForm = new CatForm(selectedEntity);
            var result = editForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var updatedEntity = editForm.Cat;

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
