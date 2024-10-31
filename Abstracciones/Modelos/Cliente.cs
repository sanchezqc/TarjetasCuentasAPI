using System.Text.Json.Serialization;

namespace Modelos
{
    public class Cliente
    {
        [JsonConstructor]
        public Cliente() { 
        }
        public Cliente(string _nombre, int _id, List<Tarjeta> listaDeTarjetas, List<Cuenta> listaDeCuentas) { 
            Id = _id;
            Nombre = _nombre;
            Cuentas = new List<Cuenta>();
            Tarjetas = new List<Tarjeta>();
            if (listaDeCuentas != null)
            Tarjetas = listaDeTarjetas.Where(x=> x.IdCliente == _id).ToList();
            if (listaDeCuentas != null)
            Cuentas = listaDeCuentas.Where(x => x.IdCliente == _id).ToList();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public List<Tarjeta> Tarjetas { get; set; }
    }
}