using Microsoft.AspNetCore.Mvc;
using TarjetasCuentasAPI.Modelos;
using TarjetasCuentasAPI.Services.Tarjetas;

namespace TarjetasCuentasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarjetasController : ControllerBase
    {
        private readonly ILogger<TarjetasController> _logger;
        private readonly ITarjetasService tarjetasService;

        public TarjetasController(ILogger<TarjetasController> logger, ITarjetasService _tarjetasService)
        {
            _logger = logger;
            tarjetasService = _tarjetasService;
        }

        [HttpGet("{idTarjeta}")]
        public ActionResult<Tarjeta> Get(int idTarjeta)
        {
            Tarjeta tarjeta= tarjetasService.ObtengaTarjetaPorID(idTarjeta);
            if(tarjeta != null)
            {
                return Ok(tarjeta);
            }
            else
            {
                return NotFound("Tarjeta no encontrada");
            }
        }
        [HttpGet()]
        public ActionResult<List<Tarjeta>> Get()
        {
            List<Tarjeta> lasTarjetas = tarjetasService.ObtengaTarjetas();
            return Ok(lasTarjetas);
        }

        //[HttpGet("/estado")]
        //public ActionResult<List<Tarjeta>> Get(string elEstado)
        //{
        //    List<Tarjeta> lasTarjetas = tarjetasService.ObtengaTarjetasPorEstado(elEstado);
        //    if (lasTarjetas != null && lasTarjetas.Count> 0)
        //    {
        //        return Ok(lasTarjetas);
        //    }
        //    else
        //    {
        //        return NotFound($"Tarjetas no encontradas para el estado: {elEstado}");
        //    }
        //}

        [HttpPost()]
        public ActionResult<List<Tarjeta>> Post([FromBody] Tarjeta laTarjeta)
        {
           Tarjeta tarjetaCreada = tarjetasService.CreeLaTarjeta(laTarjeta);
            if (tarjetaCreada != null)
            {
                return Ok(tarjetaCreada);
            }
            else
            {
                return BadRequest($"Tarjeta no creada");
            }
        }

        [HttpPut("{idTarjeta}")]
        public ActionResult<List<Tarjeta>> Put([FromBody] Tarjeta laTarjeta, int idTarjeta)
        {
            bool seActualizoLaTarjeta = tarjetasService.ActualiceLaTarjeta(laTarjeta, idTarjeta);
            if (seActualizoLaTarjeta)
            {
                return Ok("Tarjeta actualizada");
            }
            else
            {
                return BadRequest($"Tarjeta no actualizada, puede que no exista");
            }
        }
        [HttpDelete("{idTarjeta}")]
        public ActionResult<List<Tarjeta>> Delete(int idTarjeta)
        {
            bool seEliminoLaTarjeta = tarjetasService.ElimineLaTarjeta(idTarjeta);
            if (seEliminoLaTarjeta)
            {
                return Ok("Tarjeta eliminada");
            }
            else
            {
                return BadRequest($"Tarjeta no eliminada, puede que no exista");
            }
        }
    }
}
