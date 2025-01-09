namespace AdminClient
{
    /// <summary>
    /// Represents a form for searching and managing client entities.
    /// </summary>
    public partial class ClientSearchForm : SearchForm, ISearchForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSearchForm"/> class.
        /// </summary>
        public ClientSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Client and lock it
            SetEntitySelector("Client");
            DisableEntitySelector();
        }

        /// <summary>
        /// Handles the New button click event. Opens a form for creating a new client entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void newButton_Click(object sender, EventArgs e)
        {
            // Create a ClientForm and display to the user
            var clientForm = new ClientForm();
            var result = clientForm.ShowDialog();

            // If the result is bad, return
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the selected entity to the Client
            SetSelectedEntity(clientForm.Client);

            // Update the list to include the new Client
            LoadEntities();
        }
    }
}
