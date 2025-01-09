using Models;

namespace RestAPIClient
{
    public interface IPetClient : IAPIClient<PetModel>
    {
        Task<IList<IPetModel>> ListAsync();
    }
}