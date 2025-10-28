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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ClienteModel>(ClienteModel =>
            {
                ClienteModel.HasKey(c => c.Id);
                ClienteModel.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                ClienteModel.HasMany(c => c.Contatos).WithOne(c => c.Cliente).HasForeignKey(c => c.ClienteId);

            });

            modelBuilder.Entity<ContatoModel>(Contato =>
            {
                Contato.HasKey(c => c.Id);
            });

            modelBuilder.Entity<EnderecoModel>(Endereco =>
            {
                Endereco.HasKey(e => e.ClienteId);
            });

            modelBuilder.Entity<ClienteModel>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<EnderecoModel>(e => e.ClienteId);


        }



}
}
