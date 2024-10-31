using Modelos;

namespace TarjetasCuentasAPI.Services.Clientes
{
    public interface IClientesService
    {
        Cliente ObtengaClientePorId(int id);
        List<Tarjeta> ObtengaTarjetasPorCliente(int idCliente);
        List<Cuenta> ObtengaCuentasPorCliente(int idCliente);
    }
}
