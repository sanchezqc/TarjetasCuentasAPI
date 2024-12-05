using Modelos;

namespace TarjetasCuentasAPI.Services.ClienteAPIService
{
    public interface IClienteAPIService
    {
        Task<UserDto> TestHttpStatic();
        Task<ResponseDogDto> TestHttpStaticDogs();
        Task<ResponseDogDtoV2> TestHttpStaticDogsV2();
        Task<string> TestHttpStaticAll();
    }
}
