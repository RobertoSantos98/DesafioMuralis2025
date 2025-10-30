using DesafioMuralis2025.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DesafioMuralis2025.Infrastructure.Repositories.Clientes
{
    public interface IClienteRepository
    {
        Task AddAsync(ClienteModel cliente);
        Task UpdateAsync(ClienteModel cliente);
        Task<ClienteModel?> GetById(int id);
        Task<List<ClienteModel>> GetAll();
        Task DeleteAsync (int id);
        Task CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
