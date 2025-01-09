using Models;

namespace BusinessLayer
{
    public interface ICatService : IService<CatModel>
    {
        IList<CatModel> List(int ownerID);
    }
}