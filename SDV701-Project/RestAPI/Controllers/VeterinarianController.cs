using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarianController : GenericController<IVeterinarianService, VeterinarianModel>
    {
        public VeterinarianController(IVeterinarianService veterinarianService) : base(veterinarianService) { }
    }
}
