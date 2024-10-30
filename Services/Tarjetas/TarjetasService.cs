
using TarjetasCuentasAPI.Modelos;

namespace TarjetasCuentasAPI.Services.Tarjetas
{
    public class TarjetasService : ITarjetasService
    {
        public List<Tarjeta> DatosInventados { get; set; }
        public TarjetasService() { 
            DatosInventados = new List<Tarjeta>();
            DatosInventados.Add(new Tarjeta(1, 1));
            DatosInventados.Add(new Tarjeta(1, 2));
            DatosInventados.Add(new Tarjeta(2,3));
        }
        public bool ActualiceLaTarjeta(Tarjeta laTarjeta, int elIdTarjeta)
        {
            Tarjeta laTarjetaPorActualizar = DatosInventados.FirstOrDefault(a => a.Id == elIdTarjeta);
            if (laTarjetaPorActualizar == null)
            {
                return false;
            }
            ActualiceLosCampos(laTarjeta, laTarjetaPorActualizar);
            return true;
        }

        private static void ActualiceLosCampos(Tarjeta laTarjeta, Tarjeta laTarjetaPorActualizar)
        {
            laTarjetaPorActualizar.Numero = laTarjeta.Numero;
            laTarjetaPorActualizar.FechaVencimiento = laTarjeta.FechaVencimiento;
            laTarjetaPorActualizar.Estado = laTarjeta.Estado;
            laTarjetaPorActualizar.IdCliente = laTarjeta.IdCliente;
            laTarjetaPorActualizar.Emisor = laTarjeta.Emisor;
        }

        public Tarjeta CreeLaTarjeta(Tarjeta laTarjeta)
        {
            int elMaximoID = DatosInventados.Max(a => a.Id);
            laTarjeta = new Tarjeta(laTarjeta.IdCliente, elMaximoID + 1);
            DatosInventados.Add(laTarjeta);
            return laTarjeta;
        }

        public bool ElimineLaTarjeta(int elIdTarjeta)
        {
            Tarjeta laTarjetaAEliminar = DatosInventados.FirstOrDefault(a => a.Id == elIdTarjeta);
            if (laTarjetaAEliminar == null)
            {
                return false;
            }
            DatosInventados.Remove(laTarjetaAEliminar);
            return true;
        }

        public Tarjeta ObtengaTarjetaPorID(int elIdTarjeta)
        {
            Tarjeta laTarjetaBuscada = DatosInventados.FirstOrDefault(a => a.Id == elIdTarjeta);
            if (laTarjetaBuscada == null)
            {
                return null;
            }
            return laTarjetaBuscada;
        }

        public List<Tarjeta> ObtengaTarjetasPorEstado(string elEstadoBuscado)
        {
            List<Tarjeta> lasTarjetasBuscadas = DatosInventados.Where(a => a.Estado.ToLower() == elEstadoBuscado.ToLower()).ToList();
            if (lasTarjetasBuscadas == null || lasTarjetasBuscadas.Count == 0)
            {
                return new List<Tarjeta>();
            }
            return lasTarjetasBuscadas;
        }
        public List<Tarjeta> ObtengaTarjetas()
        {
            if (DatosInventados == null) return new List<Tarjeta>();
            return DatosInventados;
        }

        public List<Tarjeta> ObtengaTarjetasPorEstado(int elIdCliente)
        {
            List<Tarjeta> lasTarjetasBuscadas = DatosInventados.Where(a => a.IdCliente == elIdCliente).ToList();
            if (lasTarjetasBuscadas == null || lasTarjetasBuscadas.Count == 0)
            {
                return new List<Tarjeta>();
            }
            return lasTarjetasBuscadas;
        }
    }
}
