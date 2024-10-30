using TarjetasCuentasAPI.Modelos;
using TarjetasCuentasAPI.Services.Tarjetas;

namespace TarjetasCuentasAPI.Services.Cuentas
{
    public class CuentasService : ICuentasService
    {
        public List<Cuenta> DatosInventados { get; set; }
        
        public CuentasService()
        {
            DatosInventados = new List<Cuenta>();
            DatosInventados.Add(new Cuenta(1, 1));
            DatosInventados.Add(new Cuenta(1, 2));
            DatosInventados.Add(new Cuenta(2, 3));
        }

        public List<Cuenta> ObtengaCuentasPorIdCliente(int elIdCliente)
        {
            List<Cuenta> lasCuentas = DatosInventados.Where(a => a.IdCliente == elIdCliente).ToList();
            if (lasCuentas == null || lasCuentas.Count == 0)
            {
                return new List<Cuenta>();
            }
            return lasCuentas;
        }

        public Cuenta ObtengaCuentaPorIdCuenta(int elIdCuenta)
        {
            Cuenta laCuenteBuscada = DatosInventados.FirstOrDefault(a => a.Id == elIdCuenta);
            if (laCuenteBuscada == null)
            {
                return null;
            }
            return laCuenteBuscada;
        }

        public List<Cuenta> ObtengaCuentassPorEstado(string elEstadoBuscado)
        {
            List<Cuenta> lasCuenteBuscadas = DatosInventados.Where(a => a.Estado.ToLower() == elEstadoBuscado.ToLower()).ToList();
            if (lasCuenteBuscadas == null || lasCuenteBuscadas.Count == 0)
            {
                return new List<Cuenta>();
            }
            return lasCuenteBuscadas;
        }

        public Cuenta CreeLaCuenta(Cuenta laCuenta)
        {
            int elMaximoID = DatosInventados.Max(a => a.Id);
            Cuenta laCuentaCreada = new Cuenta(laCuenta.IdCliente, elMaximoID + 1);
            DatosInventados.Add(laCuentaCreada);
            return laCuentaCreada;
        }

        public bool ActualiceLaCuenta(Cuenta laCuenta, int elIdCuenta)
        {
            Cuenta laCuentePorActualizar = DatosInventados.FirstOrDefault(a => a.Id == elIdCuenta);
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
            Cuenta laCuentePorEliminar = DatosInventados.FirstOrDefault(a => a.Id == elIdCuenta);
            if (laCuentePorEliminar == null)
            {
                return false;
            }
            DatosInventados.Remove(laCuentePorEliminar);
            return true;
        }

        public bool BloqueeLaCuenta(int elIdCuenta)
        {
            Cuenta laCuentaPorBloquear = DatosInventados.FirstOrDefault(a => a.Id == elIdCuenta);
            if (laCuentaPorBloquear == null)
            {
                return false;
            }
            laCuentaPorBloquear.Estado = "BLOQUEADA";
            return true;
        }

        public List<Cuenta> ObtengaTodasLasCuentas()
        {
            if (DatosInventados == null) return new List<Cuenta>();
            return DatosInventados;
        }
    }
}
