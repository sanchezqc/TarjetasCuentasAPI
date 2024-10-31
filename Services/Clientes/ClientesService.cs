using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace TarjetasCuentasAPI.Services.Clientes
{
    public class ClientesService : IClientesService
    {
        private readonly BancoContext bancoContext;
        public ClientesService(BancoContext _bancoContext)
        {
            bancoContext = _bancoContext;
        }
        public Cliente ObtengaClientePorId(int id)
        {
            return bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cuenta> ObtengaCuentasPorCliente(int idCliente)
        {
            return bancoContext.Clientes.FirstOrDefault(x => x.Id == idCliente).Cuentas;
        }

        public List<Tarjeta> ObtengaTarjetasPorCliente(int idCliente)
        {
            return bancoContext.Clientes.Include(c => c.Tarjetas).FirstOrDefault(x => x.Id == idCliente).Tarjetas.ToList();
        }
    }
}
