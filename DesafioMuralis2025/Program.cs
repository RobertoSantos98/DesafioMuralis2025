using DesafioMuralis2025.Application.Providers.CepProvider;
using DesafioMuralis2025.Application.Services.ClienteServices;
using DesafioMuralis2025.Infrastructure;
using DesafioMuralis2025.Infrastructure.Repositories.Clientes;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

if (stringConnection == null)
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(stringConnection));


builder.Services.AddScoped<IClienteRepository, ClienteRepository>();



builder.Services.AddHttpClient<ICepProvider, CepProvider>();

builder.Services.AddScoped<IClienteService, ClienteService>();



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
