using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Modelos;
using TarjetasCuentasAPI.Services.Tarjetas;

namespace TarjetasCuentasAPI.Services.Cuentas
{
    public class CuentasService : ICuentasService
    {
        private readonly BancoContext _bancoContext;

        public CuentasService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Cuenta> ObtengaCuentasPorIdCliente(int elIdCliente)
        {
            return _bancoContext.Cuentas.Where(a => a.IdCliente == elIdCliente).AsNoTracking().ToList()
                ?? new List<Cuenta>();

        }

        public Cuenta ObtengaCuentaPorIdCuenta(int elIdCuenta)
        {
            return _bancoContext.Cuentas.FirstOrDefault(a => a.Id == elIdCuenta);
        }

        public List<Cuenta> ObtengaCuentassPorEstado(string elEstadoBuscado)
        {
            return _bancoContext.Cuentas.Where(a => a.Estado.ToLower() == elEstadoBuscado.ToLower()).ToList()
                ?? new List<Cuenta>();
        }

        public Cuenta CreeLaCuenta(Cuenta laCuenta)
        {
            _bancoContext.Cuentas.Add(laCuenta);
            _bancoContext.SaveChanges();
            return laCuenta;
        }

        public bool ActualiceLaCuenta(Cuenta laCuenta, int elIdCuenta)
        {
            Cuenta laCuentePorActualizar = _bancoContext.Cuentas.FirstOrDefault(a => a.Id == elIdCuenta);
            if (laCuentePorActualizar == null)
            {
                return false;
            }
            ActualiceLosCampos(laCuenta, laCuentePorActualizar);
            return true;
        }

        private static void ActualiceLosCampos(Cuenta laCuenta, Cuenta laCuentaPorActualizar)
        {
            laCuentaPorActualizar.NumeroDeCuenta = laCuenta.NumeroDeCuenta;
            laCuentaPorActualizar.Tipo = laCuenta.Tipo;
            laCuentaPorActualizar.Estado = laCuenta.Estado;
            laCuentaPorActualizar.IdCliente = laCuenta.IdCliente;
            laCuentaPorActualizar.Moneda = laCuenta.Moneda;
        }

    public bool ElimineLaCuenta(int elIdCuenta)
        {
            Cuenta laCuentePorEliminar = _bancoContext.Cuentas.FirstOrDefault(a => a.Id == elIdCuenta);
            if (laCuentePorEliminar == null)
            {
                return false;
            }
            _bancoContext.Cuentas.Remove(laCuentePorEliminar);
            _bancoContext.SaveChanges();
            return true;
        }

        public bool BloqueeLaCuenta(int elIdCuenta)
        {
            Cuenta laCuentaPorBloquear = _bancoContext.Cuentas.FirstOrDefault(a => a.Id == elIdCuenta);
            if (laCuentaPorBloquear == null)
            {
                return false;
            }
            laCuentaPorBloquear.Estado = "BLOQUEADA";
            _bancoContext.Cuentas.Update(laCuentaPorBloquear);
            _bancoContext.SaveChanges();
            return true;
        }

        public List<Cuenta> ObtengaTodasLasCuentas()
        {
            return _bancoContext.Cuentas.AsNoTracking().ToList();
        }
    }
}
