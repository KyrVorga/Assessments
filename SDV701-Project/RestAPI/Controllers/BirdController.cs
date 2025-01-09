using BusinessLayer;
using Models;

namespace RestAPI.Controllers
{
    public class BirdController : GenericController<IBirdService, BirdModel>
    {
        public BirdController(IBirdService birdService) : base(birdService)
        {
        }
    }
}
