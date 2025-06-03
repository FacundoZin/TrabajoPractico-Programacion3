using Microsoft.EntityFrameworkCore;
using TrabajoPraactico_Programaci�n3.Data;
using TrabajoPraactico_Programaci�n3.Interfaces;
using TrabajoPraactico_Programaci�n3.Repository;
using TrabajoPraactico_Programaci�n3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IGastosRepository, GastosRepository>();
builder.Services.AddScoped<IGastosServices, GastosService>();   

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
