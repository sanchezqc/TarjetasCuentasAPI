using TarjetasCuentasAPI.Services.Clientes;
using TarjetasCuentasAPI.Services.Cuentas;
using TarjetasCuentasAPI.Services.Tarjetas;
using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace TarjetasCuentasAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BancoContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bccr;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            });



            builder.Services.AddScoped<ITarjetasService, TarjetasService>();
            builder.Services.AddScoped<ICuentasService, CuentasService>();
            builder.Services.AddScoped<IClientesService, ClientesService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
