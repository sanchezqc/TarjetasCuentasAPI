using System.Text.Json.Serialization;

namespace Modelos
{
    public class Cliente
    {
        [JsonConstructor]
        public Cliente() { 
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public virtual ICollection<Tarjeta> Tarjetas { get; set; }
        public string? Direccion { get; set; }
    }
}
