using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Infrastructure.Repositories.Contato
{
    public interface IContatoRepository
    {
        Task AddAsync(ContatoModel contato);
        Task UpdateAsync(ContatoModel contato);
        Task DeleteAsync (int id);
        Task<ContatoModel?> GetById(int id);
        Task CommitAsync();
    }
}
