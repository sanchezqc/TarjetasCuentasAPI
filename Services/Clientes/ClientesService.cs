using TarjetasCuentasAPI.Modelos;
using TarjetasCuentasAPI.Services.Tarjetas;

namespace TarjetasCuentasAPI.Services.Clientes
{
    public class ClientesService : IClientesService
    {
        List<Cliente> DatosInventados;
        private TarjetasService tarjetaService = new TarjetasService();
        public ClientesService() {
            DatosInventados = new List<Cliente>();
            DatosInventados.Add(new Cliente("Pedro", 1, tarjetaService.DatosInventados));

        }
        public Cliente ObtengaClientePorId(int id)
        {
            return DatosInventados.FirstOrDefault(x => x.Id == id);
        }

        public List<Cuenta> ObtengaCuentasPorCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public List<Tarjeta> ObtengaTarjetasPorCliente(int idCliente)
        {
            return DatosInventados.FirstOrDefault(x => x.Id == idCliente).Tarjetas;
        }
    }
}
