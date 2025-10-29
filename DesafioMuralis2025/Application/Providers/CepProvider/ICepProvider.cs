using DesafioMuralis2025.Domain.DTOs;

namespace DesafioMuralis2025.Application.Providers.CepProvider
{
    public interface ICepProvider
    {
        Task<EnderecoDTO?> GetAddressByCepAsync(string cep);
    }
}
