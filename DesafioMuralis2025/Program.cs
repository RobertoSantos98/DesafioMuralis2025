using DesafioMuralis2025.Application.Providers.CepProvider;
using DesafioMuralis2025.Infrastructure;
using DesafioMuralis2025.Infrastructure.Repositories.Clientes;
using DesafioMuralis2025.Infrastructure.Repositories.Contato;
using DesafioMuralis2025.Infrastructure.Repositories.Endereco;
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
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();


builder.Services.AddHttpClient<ICepProvider, CepProvider>();



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
