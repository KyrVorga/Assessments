using Models;

namespace BusinessLayer
{
    public interface IBirdService : IService<BirdModel>
    {
        IList<BirdModel> List(int ownerID);
    }
}