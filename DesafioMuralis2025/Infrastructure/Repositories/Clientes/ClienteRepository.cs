using DesafioMuralis2025.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DesafioMuralis2025.Infrastructure.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClienteModel cliente)
        {
            await _context.AddAsync(cliente);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteModel?> GetById(int id)
        {
            return await _context.Clientes.Include(c => c.Endereco).Include(c=> c.Contatos).FirstOrDefaultAsync(c=> c.Id == id);
        }

        public async Task<List<ClienteModel>> GetAll()
        {
            return await _context.Clientes
                .Include(c => c.Endereco)
                .Include(c => c.Contatos)
                .ToListAsync();
        }

        public async Task UpdateAsync(ClienteModel cliente)
        {
            _context.Update(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
                _context.Clientes.Remove(cliente);
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
