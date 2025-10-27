using DesafioMuralis2025.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMuralis2025.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<EnderecoModel> Endereco { get; set; }



}
}
