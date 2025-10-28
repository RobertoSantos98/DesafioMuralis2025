using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Infrastructure.Repositories.Endereco
{
    public interface IEnderecoRepository
    {
        Task AddAsync(EnderecoModel endereco);
        Task UpdateAsync(EnderecoModel endereco);
        Task<EnderecoModel?> GetById(int id);
        Task DeleteAsync (EnderecoModel endereco);
        Task CommitAsync();
    }
}
