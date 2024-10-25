namespace TarjetasCuentasAPI.Modelos
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string? NumeroDeCuenta { get; set; }
        public string? Moneda { get; set; }
        public string? Estado { get; set; }
        public int IdCliente { get; set; }
        public string Tipo { get; set; }
    }
}
