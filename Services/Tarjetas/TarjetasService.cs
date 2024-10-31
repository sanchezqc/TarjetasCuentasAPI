using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace TarjetasCuentasAPI.Services.Tarjetas
{
    public class TarjetasService : ITarjetasService
    {
        private readonly BancoContext bancoContext;

        public TarjetasService(BancoContext _bancoContext)
        {
            bancoContext = _bancoContext;   
        }

        public bool ActualiceLaTarjeta(Tarjeta laTarjeta, int elIdTarjeta)
        {
            Tarjeta laTarjetaPorActualizar = bancoContext.Tarjetas.FirstOrDefault(a => a.Id == elIdTarjeta);
            if (laTarjetaPorActualizar == null)
            {
                return false;
            }
            ActualiceLosCampos(laTarjeta, laTarjetaPorActualizar);
            bancoContext.SaveChanges();
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
            int elMaximoID = bancoContext.Tarjetas.Max(a => a.Id);
            bancoContext.Tarjetas.Add(laTarjeta);
            return laTarjeta;
        }

        public bool ElimineLaTarjeta(int elIdTarjeta)
        {
            Tarjeta laTarjetaAEliminar = bancoContext.Tarjetas.FirstOrDefault(a => a.Id == elIdTarjeta);
            if (laTarjetaAEliminar == null)
            {
                return false;
            }
            bancoContext.Tarjetas.Remove(laTarjetaAEliminar);
            bancoContext.SaveChanges();
            return true;
        }

        public Tarjeta ObtengaTarjetaPorID(int elIdTarjeta)
        {
            Tarjeta laTarjetaBuscada = bancoContext.Tarjetas.FirstOrDefault(a => a.Id == elIdTarjeta);
            if (laTarjetaBuscada == null)
            {
                return null;
            }
            return laTarjetaBuscada;
        }

        public List<Tarjeta> ObtengaTarjetasPorEstado(string elEstadoBuscado)
        {
            List<Tarjeta> lasTarjetasBuscadas = bancoContext.Tarjetas.Where(a => a.Estado.ToLower() == elEstadoBuscado.ToLower()).ToList();
            if (lasTarjetasBuscadas == null || lasTarjetasBuscadas.Count == 0)
            {
                return new List<Tarjeta>();
            }
            return lasTarjetasBuscadas;
        }
        public List<Tarjeta> ObtengaTarjetas()
        {
            if (!bancoContext.Tarjetas.Any()) return new List<Tarjeta>();
            return bancoContext.Tarjetas.ToList();
        }

        public List<Tarjeta> ObtengaTarjetasPorCliente(int elIdCliente)
        {
            List<Tarjeta> lasTarjetasBuscadas = bancoContext.Tarjetas.Where(a => a.IdCliente == elIdCliente).ToList();
            if (lasTarjetasBuscadas == null || lasTarjetasBuscadas.Count == 0)
            {
                return new List<Tarjeta>();
            }
            return lasTarjetasBuscadas;
        }

        public void Migracion()
        {
            bancoContext.Database.EnsureCreated();
        }
    }
}
