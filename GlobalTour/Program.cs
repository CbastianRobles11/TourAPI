using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1.capturar nuestra cadena de conexion de appsettings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//2.agregamos el servicio 
//este es nuestro dbContext le pusiimos ApllicationDbContext y mandamos la conexion
builder.Services.AddDbContext<ApplicationDbContext>(options => 
//conexion mysql(conexion,version server
options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


//para ejecutar las migraciones necesitamos instalar 2 paketes
//1.dotnet - ef sacado de este link https://www.nuget.org/packages/dotnet-ef/7.0.0-preview.2.22153.1 he instalar por consola
//2. en nugets instalar entityframeworkCore.Desing he instalar
//
// luego tenemos que ejecutar en consola los siguientes comandos
// dotnet ef -h para ver que cmandos usar
// dotnet ef migrations add MigracionInicial -o Datos/Migrations de esta manera se crea la primera migracion 
//dotnet ef database update === hara se actualize en la bbd que tenemos configurada

