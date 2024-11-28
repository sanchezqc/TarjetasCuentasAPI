using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System.Text.Json;

namespace TarjetasCuentasAPI.Services.ClienteAPIService
{
    public class ClienteAPIService : IClienteAPIService
    {
        //sin base adress
        private static readonly HttpClient _httpClient = new HttpClient();
        //con base adress
        private static HttpClient staticClient = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
        };
        public ClienteAPIService()
        {
           
        }

        //public async void ObtenerDatos()
        //{
        //    string responseBody = await staticCliente.GetStringAsync("https://dog.ceo/api/breed/hound/afghan/images/random")
        //}

        public async Task<UserDto> TestHttpStatic()
        {
            try
            {
                string responseBody = await staticClient.GetStringAsync("/todos/1");
                UserDto res = JsonSerializer.Deserialize<UserDto>(responseBody);
                Console.WriteLine(res);
                return res;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public async Task<ResponseDogDto> TestHttpStaticDogs()
        {
            try
            {
                string responseBody = await _httpClient.GetStringAsync("https://dog.ceo/api/breed/hound/afghan/images/random");
                ResponseDogDto res = JsonSerializer.Deserialize<ResponseDogDto>(responseBody);
                Console.WriteLine(res);
                return res;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public async Task<string> TestHttpStaticAll()
        {
            try
            {
                string responseBody = await staticClient.GetStringAsync("/todos/");
                List<UserDto> res = JsonSerializer.Deserialize<List<UserDto>>(responseBody);
                Console.WriteLine(res);
                int totalCompletados = res.Where(x=>x.completed).ToList().Count;
                int totalNoCompletados = res.Where(x => !x.completed).ToList().Count;
                return $"existen {totalCompletados} completados y {totalNoCompletados} sin completar";
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }

    

    public class UserDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public bool completed { get; set; }
        public string title { get; set; }
    }

    public class ResponseDogDto
    {
        public string message { get; set; }
        public string status { get; set; }
    }
}
