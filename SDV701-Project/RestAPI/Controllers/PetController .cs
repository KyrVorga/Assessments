using BusinessLayer;
using Models;

namespace RestAPI.Controllers
{
    public class PetController : GenericController<IPetService, IPetModel>
    {
        public PetController(IPetService petService) : base(petService)
        {
        }
    }
}
