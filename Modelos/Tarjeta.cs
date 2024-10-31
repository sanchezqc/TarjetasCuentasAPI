using System.Text.Json.Serialization;

namespace TarjetasCuentasAPI.Modelos
{
    public class Tarjeta
    {
        [JsonConstructor]
        public Tarjeta() { }
        public DateTime FechaVencimiento { get; set; }
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Emisor { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente{ get; set; }
        public string? Estado { get; set; }
    }
}
