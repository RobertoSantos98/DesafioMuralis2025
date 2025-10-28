using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Infrastructure.Repositories.Endereco
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Models.EnderecoModel endereco)
        {
            await _context.AddAsync(endereco);
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<EnderecoModel?> GetById(int id)
        {
            return await _context.Endereco.FindAsync(id);
        }
        public async Task UpdateAsync(EnderecoModel endereco)
        {
            _context.Update(endereco);
        }
        public async Task DeleteAsync(EnderecoModel endereco)
        {
            _context.Endereco.Remove(endereco);
        }
    }
}
