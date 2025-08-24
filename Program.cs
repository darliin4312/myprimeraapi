using Microsoft.EntityFrameworkCore;
using MiPrimerAPI.Data;
using MiPrimerAPI.Repositories;
using MiPrimerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configuración de EF Core con SQL Server (usa la conexión de appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Inyección de dependencias
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddHttpClient<ExternalApiService>();

// 🔹 Configuración de Controllers y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Recomendado, redirige HTTP a HTTPS
app.UseAuthorization();

app.MapControllers(); // 🔹 Activa los Controllers

app.Run();

builder.Services.AddHttpClient<ExternalApiService>();
