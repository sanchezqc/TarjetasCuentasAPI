namespace TarjetasCuentasAPI.Modelos
{
    public class Cliente
    {

        public int Id { get; set; }

        public string? Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public List<Tarjeta> Tarjetas { get; set; }
    }
}
