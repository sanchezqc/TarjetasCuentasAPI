using System.Text;

namespace TarjetasCuentasAPI.Middleware
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;

        public TimeMiddleware (RequestDelegate nextRequestDelegate)
        {
            next = nextRequestDelegate;
        }

        public  async Task InvokeAsync (HttpContext context)
        {
            // Interceptamos el stream de respuesta original
            Console.WriteLine("El Middleware Funciona");
            var originalBodyStream = context.Response.Body;

            // Creamos un stream temporal para capturar la salida
            using (var newBodyStream = new MemoryStream())
            {
                // Reemplazamos el stream de respuesta con el nuevo
                context.Response.Body = newBodyStream;
                // Dejamos que los otros middlewares o el controlador hagan su trabajo
                await next(context);
                // Leemos el contenido modificado de la respuesta
                newBodyStream.Seek(0, SeekOrigin.Begin);
                var newContent = await new StreamReader(newBodyStream).ReadToEndAsync();
                // Añadimos la fecha actual al final del contenido de la respuesta
                var updatedContent = newContent + $"\nCurrent Date: {DateTime.Now}\n";
                // Escribimos el contenido actualizado al stream de respuesta original
                var responseBytes = Encoding.UTF8.GetBytes(updatedContent);
                await originalBodyStream.WriteAsync(responseBytes, 0, responseBytes.Length);
            }
        }
    }
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    } 
}
