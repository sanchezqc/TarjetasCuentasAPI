using Modelos;

namespace TarjetasCuentasAPI.Services.ClienteAPIService
{
    public interface IClienteAPIService
    {
        Task<UserDto> TestHttpStatic();
        Task<ResponseDogDto> TestHttpStaticDogs();
        Task<string> TestHttpStaticAll();
    }
}
