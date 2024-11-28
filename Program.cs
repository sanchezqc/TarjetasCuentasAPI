using TarjetasCuentasAPI.Services.Clientes;
using TarjetasCuentasAPI.Services.Cuentas;
using TarjetasCuentasAPI.Services.Tarjetas;
using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TarjetasCuentasAPI.Middleware;
using TarjetasCuentasAPI.SwaggerFilters;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using TarjetasCuentasAPI.DA;
using TarjetasCuentasAPI.Services.ClienteAPIService;

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
            //verion basica
            builder.Services.AddSwaggerGen();
            //version investigada
            //builder.Services.AddSwaggerGen(c=> c.OperationFilter<AddHeaderParameters>());
            //////////version con el profe
            ////builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", 
            ////    new OpenApiInfo { Title = "AuthCore API", Version = "v1" }); 
            ////    c.AddSecurityDefinition("ApiKey", 
            ////        new OpenApiSecurityScheme { 
            ////            Name = "API_KEY", 
            ////            In = ParameterLocation.Header, 
            ////            Type = SecuritySchemeType.ApiKey, 
            ////            Description = "Authorization by x-api-key inside request's header", 
            ////            Scheme = "ApiKeyScheme" }); 
            ////    var key = new OpenApiSecurityScheme() { 
            ////        Reference = new OpenApiReference { 
            ////            Type = ReferenceType.SecurityScheme, 
            ////            Id = "ApiKey" }, 
            ////        In = ParameterLocation.Header 
            ////    }; 
            ////    var requirement = new OpenApiSecurityRequirement { 
            ////        { key, 
            ////            new List<string>()
            ////        }}; 
            ////    c.AddSecurityRequirement(requirement); 
            ////});
            //builder.Services.AddDbContext<BancoContext>(p=> p.UseInMemoryDatabase("Bccr"));.
            builder.Services.AddSqlServer<ApplicationDbContext>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=conIdentity;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            builder.Services.AddAuthorization();
          /*  builder.Services.AddIdentityApiEndpoints<IdentityUser>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = true;
            }).AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();
          */



            builder.Services.AddScoped<IClienteAPIService, ClienteAPIService>();
            //builder.Services.AddScoped<ITarjetasService, TarjetasService>();
            //builder.Services.AddScoped<ICuentasService, CuentasService>();
            //builder.Services.AddScoped<IClientesService, ClientesService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            // se deben colocar los middleware custom de ultimos 
            //app.UseTimeMiddleware();
            // en postman se tendria que agregar en el header
            //app.UseApiKeyMiddleware();
            //app.MapIdentityApi<IdentityUser>();
            app.MapControllers();
            app.Run();
        }
    }
}
