using Models;

namespace AdminClient.Controls.Collections
{
    public partial class VeterinarianCollectionControl : EntityCollectionControl<VeterinarianModel, VeterinarianSearchForm, VeterinarianForm>
    {
        public VeterinarianCollectionControl()
        {
            InitializeComponent();

            UpdateDisplayText("Veterinarians");

            Entities = new List<VeterinarianModel>();

        }

        protected override void AddEntity()
        {
            // On add, open the Veterinarian search form
            // add the veterinarian that's returned, to the list of entities

            // Open the search form
            var searchForm = new VeterinarianSearchForm();
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
                MessageBox.Show("Veterinarian already exists in the list.");
                return;
            }

            // Add the selected entity to the list
            if (selectedEntity != null)
            {
                Entities.Add((VeterinarianModel)selectedEntity);
            }
        }

        protected override void UpdateEntity(VeterinarianModel selectedEntity)
        {
            // On update, open the Veterinarian form on the selected entity
            // update the veterinarian in the list of entities

            // Open the edit form
            var editForm = new VeterinarianForm(selectedEntity);
            var result = editForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var updatedEntity = editForm.Veterinarian;

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
