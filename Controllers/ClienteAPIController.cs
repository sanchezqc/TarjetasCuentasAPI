using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using TarjetasCuentasAPI.Modelos;
using TarjetasCuentasAPI.Services.ClienteAPIService;

namespace TarjetasCuentasAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteAPIController : ControllerBase
    {
        private readonly IClienteAPIService clienteService;

        public ClienteAPIController(IClienteAPIService _clienteService)
        {
            clienteService = _clienteService;
        }

        //[HttpGet()]
        //public ActionResult<UserDto> Get()
        //{
        //   return clienteService.TestHttpStatic().Result;
            
        //}

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public ActionResult<ResponseDogDto> GetDogs()
        {
            return clienteService.TestHttpStaticDogs().Result;

        }


        [MapToApiVersion("2.0")]
        [HttpGet()]
        public ActionResult<ResponseDogDtoV2> GetDogsV2()
        {
            return clienteService.TestHttpStaticDogsV2().Result;

        }

        [HttpGet("GetTodos")]
        public ActionResult<string> GetTodos()
        {
            return clienteService.TestHttpStaticAll().Result;

        }
    }
}
