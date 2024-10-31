using Microsoft.AspNetCore.Mvc;
using Modelos;
using TarjetasCuentasAPI.Services.Cuentas;

namespace TarjetasCuentasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ILogger<CuentasController> _logger;
        private readonly ICuentasService cuentasService;

        public CuentasController(ILogger<CuentasController> logger, ICuentasService _cuentasService)
        {
            _logger = logger;
            cuentasService = _cuentasService;
        }

        [HttpGet("{idCuenta}")]
        public ActionResult<Cuenta> Get(int idCuenta)
        {
            Cuenta laCuenta= cuentasService.ObtengaCuentaPorIdCuenta(idCuenta);
            if(laCuenta != null)
            {
                return Ok(laCuenta);
            }
            else
            {
                return NotFound("Cuenta no encontrada");
            }
        }
        //[HttpGet("{elIdCliente}")]
        //public ActionResult<List<Cuenta>> ObtengaCuentasPorIdCliente(int elIdCliente)
        //{
        //    List<Cuenta> lasCuentas = cuentasService.ObtengaCuentasPorIdCliente(elIdCliente);
        //    return Ok(lasCuentas);
        //}

        //[HttpGet("/estado")]
        //public ActionResult<List<Cuenta>> Get(string elEstado)
        //{
        //    List<Cuenta> lasCuentas = cuentasService.ObtengaTarjetasPorEstado(elEstado);
        //    if (lasCuentas != null && lasCuentas.Count> 0)
        //    {
        //        return Ok(lasCuentas);
        //    }
        //    else
        //    {
        //        return NotFound($"Cuentas no encontradas para el estado: {elEstado}");
        //    }
        //}

        [HttpPost()]
        public ActionResult<Cuenta> Post([FromBody] Cuenta laCuenta)
        {
           Cuenta laCuentaCreada = cuentasService.CreeLaCuenta(laCuenta);
            if (laCuentaCreada != null)
            {
                return Ok(laCuentaCreada);
            }
            else
            {
                return BadRequest($"Cuenta no creada");
            }
        }

        [HttpPut("{idCuenta}")]
        public ActionResult<Cuenta> Put([FromBody] Cuenta laCuenta, int idCuenta)
        {
            bool seActualizoLaCuenta = cuentasService.ActualiceLaCuenta(laCuenta, idCuenta);
            if (seActualizoLaCuenta)
            {
                return Ok("Cuenta actualizada");
            }
            else
            {
                return BadRequest($"Cuenta no actualizada, puede que no exista");
            }
        }
        [HttpPut(Name ="Bloquear cuenta")]
        public ActionResult<Cuenta> Bloquear([FromQuery] int idCuenta)
        {
            bool seActualizoLaCuenta = cuentasService.BloqueeLaCuenta(idCuenta);
            if (seActualizoLaCuenta)
            {
                return Ok("Cuenta bloqueada");
            }
            else
            {
                return BadRequest($"Cuenta no bloqueada, puede que no exista");
            }
        }
        [HttpDelete("{idCuenta}")]
        public ActionResult<Cuenta> Delete(int idCuenta)
        {
            bool seEliminoLaCuenta = cuentasService.ElimineLaCuenta(idCuenta);
            if (seEliminoLaCuenta)
            {
                return Ok("Cuenta eliminada");
            }
            else
            {
                return BadRequest($"Cuenta no eliminada, puede que no exista");
            }
        }
    }
}
