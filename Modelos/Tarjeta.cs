using System.Text.Json.Serialization;

namespace TarjetasCuentasAPI.Modelos
{
    public class Tarjeta
    {
        [JsonConstructor]
        public Tarjeta() { }
        public Tarjeta(int elIdCliente, int elId)
        {
            FechaVencimiento = DateOnly.FromDateTime(DateTime.Now.AddDays(Random.Shared.Next(1, 300)));
            Numero = string.Concat("1234-5678-9876-", Random.Shared.NextInt64(1000, 9999).ToString("0000"));
            Emisor = "VISA";
            IdCliente = elIdCliente;
            Estado = "Activa";
            Id = elId;
        }
        public DateOnly FechaVencimiento { get; set; }
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Emisor { get; set; }
        public int IdCliente { get; set; }
        public string? Estado { get; set; }
    }
}
