using Microsoft.AspNetCore.Components.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;

namespace TarjetasCuentasAPI.Modelos
{
    public class Cuenta
    {

        [JsonConstructor]
        public Cuenta() { }
        public Cuenta(int elIdCliente, int elId)
        {
            Id = elId;
            NumeroDeCuenta = string.Concat("1234", Random.Shared.NextInt64(1000, 9999).ToString("0000"));
            Moneda = "COLONES";
            Estado = "Activa";
            IdCliente = elIdCliente;
            Tipo = "AHO";
        }

        public int Id { get; set; }
        public string? NumeroDeCuenta { get; set; }
        public string? Moneda { get; set; }
        public string? Estado { get; set; }
        public int IdCliente { get; set; }
        public string? Tipo { get; set; }
    }
}
