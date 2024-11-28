using Microsoft.AspNetCore.Mvc;
using Modelos;
using TarjetasCuentasAPI.Modelos;
using TarjetasCuentasAPI.Services.ClienteAPIService;

namespace TarjetasCuentasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteAPIController : ControllerBase
    {
        private readonly IClienteAPIService clienteService;

        public ClienteAPIController(IClienteAPIService _clienteService)
        {
            clienteService = _clienteService;
        }

        [HttpGet()]
        public ActionResult<UserDto> Get()
        {
           return clienteService.TestHttpStatic().Result;
            
        }

        [HttpGet("GetDogs")]
        public ActionResult<ResponseDogDto> GetDogs()
        {
            return clienteService.TestHttpStaticDogs().Result;

        }

        [HttpGet("GetTodos")]
        public ActionResult<string> GetTodos()
        {
            return clienteService.TestHttpStaticAll().Result;

        }
    }
}
