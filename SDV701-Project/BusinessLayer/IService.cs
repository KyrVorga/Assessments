namespace BusinessLayer
{
    public interface IService<TModel> /*where TModel : class*/
    {
        int Add(TModel model);
        void Delete(int id);
        TModel Get(int id);
        IList<TModel> List();
        IList<TModel> Search(Dictionary<string, List<FilterCriteria>> filters);
        int Update(TModel model);
    }
}