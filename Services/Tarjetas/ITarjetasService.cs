using Modelos;

namespace TarjetasCuentasAPI.Services.Tarjetas
{
    public interface ITarjetasService
    {
        List<Tarjeta> ObtengaTarjetas();
        Tarjeta ObtengaTarjetaPorID(int elIdTarjeta);
        List<Tarjeta> ObtengaTarjetasPorEstado(string elEstadoBuscado);
        List<Tarjeta> ObtengaTarjetasPorEstado(int elIdCliente);
        Tarjeta CreeLaTarjeta(Tarjeta laTarjeta);
        bool ActualiceLaTarjeta(Tarjeta laTarjeta, int elIdTarjeta);
        bool ElimineLaTarjeta(int elIdTarjeta);

    }
}
