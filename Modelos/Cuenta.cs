using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;

namespace Modelos
{
    public class Cuenta
    {

        [JsonConstructor]
        public Cuenta() { }
        public int Id { get; set; }
        public string? NumeroDeCuenta { get; set; }
        public string? Moneda { get; set; }
        public string? Estado { get; set; }
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public string? Tipo { get; set; }
    }
}
