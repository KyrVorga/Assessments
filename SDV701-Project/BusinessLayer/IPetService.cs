using Models;

namespace BusinessLayer
{
    public interface IPetService : IService<IPetModel>
    {
        new IList<IPetModel> List();
    }
}