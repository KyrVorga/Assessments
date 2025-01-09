namespace AdminClient.Controls.Searches
{
    public interface ISearchControl
    {
        object GetSelectedEntity();
        void InitializeAPIClients();
        void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null);
    }
}