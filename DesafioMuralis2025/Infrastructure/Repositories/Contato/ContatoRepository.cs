using DesafioMuralis2025.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMuralis2025.Infrastructure.Repositories.Contato
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;
        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ContatoModel contato)
        {
            await _context.AddAsync(contato);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Contatos.Where(c => c.Id == id).ExecuteDeleteAsync();
        }

        public async Task<ContatoModel?> GetById(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task UpdateAsync(ContatoModel contato)
        {
            _context.Update(contato);
        }
    }
}
