namespace TarjetasCuentasAPI.Modelos
{
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
