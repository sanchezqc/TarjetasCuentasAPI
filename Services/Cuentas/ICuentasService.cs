using Modelos;

namespace TarjetasCuentasAPI.Services.Cuentas
{
    public interface ICuentasService
    {
        List<Cuenta> ObtengaCuentasPorIdCliente(int elIdCliente);
        Cuenta ObtengaCuentaPorIdCuenta(int elIdCuenta);
        List<Cuenta> ObtengaCuentassPorEstado(string elEstadoBuscado);
        Cuenta CreeLaCuenta(Cuenta laCuenta);
        bool ActualiceLaCuenta(Cuenta laCuenta, int elIdCuenta);
        bool BloqueeLaCuenta(int elIdCuenta);
        bool ElimineLaCuenta(int elIdCuenta);
        List<Cuenta> ObtengaTodasLasCuentas();
    }
}
