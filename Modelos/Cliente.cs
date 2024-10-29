using System.Text.Json.Serialization;

namespace TarjetasCuentasAPI.Modelos
{
    public class Cliente
    {
        [JsonConstructor]
        public Cliente() { 
        }
        public Cliente(string _nombre, int _id, List<Tarjeta> listaDeTarjetas) { 
            Id = _id;
            Nombre = _nombre;
            Cuentas = new List<Cuenta>();
            Tarjetas = new List<Tarjeta>();
            Tarjetas = listaDeTarjetas.Where(x=> x.IdCliente == _id).ToList();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public List<Tarjeta> Tarjetas { get; set; }
    }
}
