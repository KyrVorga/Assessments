using Models;

namespace AdminClient.Controls.Collections
{
    public partial class ClientCollectionControl : EntityCollectionControl<ClientModel, ClientSearchForm, ClientForm>
    {
        public ClientCollectionControl()
        {
            InitializeComponent();

            UpdateDisplayText("Clients");

            Entities = new List<ClientModel>();

        }

        protected override void AddEntity()
        {
            // On add, open the Client search form
            // add the client that's returned, to the list of entities

            // Open the search form
            var searchForm = new ClientSearchForm();
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
                MessageBox.Show("Client already exists in the list.");
                return;
            }

            // Add the selected entity to the list
            if (selectedEntity != null)
            {
                Entities.Add((ClientModel)selectedEntity);
            }
        }

        protected override void UpdateEntity(ClientModel selectedEntity)
        {
            // On update, open the Client form on the selected entity
            // update the client in the list of entities

            // Open the edit form
            var editForm = new ClientForm(selectedEntity);
            var result = editForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            var updatedEntity = editForm.Client;

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
