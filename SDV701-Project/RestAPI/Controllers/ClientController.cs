using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : GenericController<IClientService, ClientModel>
    {
        public ClientController(IClientService clientService) : base(clientService)
        {
        }
    }
}
