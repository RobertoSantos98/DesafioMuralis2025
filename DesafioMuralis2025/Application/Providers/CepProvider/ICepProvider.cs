namespace DesafioMuralis2025.Application.Providers.CepProvider
{
    public interface ICepProvider
    {
        Task<string?> GetAddressByCepAsync(string cep);
    }
}
