using TarjetasCuentasAPI.Modelos;
using TarjetasCuentasAPI.Services.Cuentas;
using TarjetasCuentasAPI.Services.Tarjetas;

namespace TarjetasCuentasAPI.Services.Clientes
{
    public class ClientesService : IClientesService
    {
        List<Cliente> DatosInventados;
        private readonly ITarjetasService ITarjetasService;
        private readonly ICuentasService ICuentasService;
        public ClientesService(ITarjetasService _ITarjetaService, ICuentasService _ICuentasService)
        {
            ITarjetasService = _ITarjetaService;
            ICuentasService = _ICuentasService;
            DatosInventados = new List<Cliente>();
            DatosInventados.Add(new Cliente("Pedro", 1, ITarjetasService.ObtengaTarjetas(), ICuentasService.ObtengaTodasLasCuentas()));

        }
        public Cliente ObtengaClientePorId(int id)
        {
            RefresqueDatos();
            return DatosInventados.FirstOrDefault(x => x.Id == id);
        }

        public List<Cuenta> ObtengaCuentasPorCliente(int idCliente)
        {
            RefresqueDatos();
            return DatosInventados.FirstOrDefault(x => x.Id == idCliente).Cuentas;
        }

        public List<Tarjeta> ObtengaTarjetasPorCliente(int idCliente)
        {
            RefresqueDatos();
            return DatosInventados.FirstOrDefault(x => x.Id == idCliente).Tarjetas;
        }
        private void RefresqueDatos()
        {
            foreach (var item in DatosInventados)
            {
                item.Tarjetas = ITarjetasService.ObtengaTarjetas();
                item.Cuentas = ICuentasService.ObtengaTodasLasCuentas();
            }
        }
    }
}
