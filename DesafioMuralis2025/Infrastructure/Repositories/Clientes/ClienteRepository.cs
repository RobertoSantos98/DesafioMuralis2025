using DesafioMuralis2025.Domain.Models;

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
            return await _context.Clientes.FindAsync(id);
        }

        public async Task UpdateAsync(ClienteModel cliente)
        {
            _context.Update(cliente);
        }
        public async Task DeleteAsync(ClienteModel cliente)
        {
            _context.Clientes.Remove(cliente);
        }
    }
}
