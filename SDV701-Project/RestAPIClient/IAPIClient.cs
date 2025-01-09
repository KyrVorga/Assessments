namespace RestAPIClient
{
    public interface IAPIClient<TModel>
    {
        Task<bool> DeleteAsync(int id);
        Task<int> AddAsync(TModel model);
        Task<TModel> GetAsync(int id);
        Task<IList<TModel>> ListAsync();
        Task<int> UpdateAsync(TModel model);
        Task<IList<TModel>> SearchAsync(Dictionary<string, List<FilterCriteria>> filters);
    }
}
