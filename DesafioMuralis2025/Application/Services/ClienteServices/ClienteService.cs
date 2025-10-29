using DesafioMuralis2025.Application.Providers.CepProvider;
using DesafioMuralis2025.Application.Request;
using DesafioMuralis2025.Domain.DTOs;
using DesafioMuralis2025.Domain.Models;
using DesafioMuralis2025.Infrastructure.Repositories.Clientes;

namespace DesafioMuralis2025.Application.Services.ClienteServices
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ICepProvider _cepProvider;
        public ClienteService(IClienteRepository clienteRepository, ICepProvider cepProvider)
        {
            _clienteRepository = clienteRepository;
            _cepProvider = cepProvider;
        }

        public Task<ResponseModel<ClienteDTO>> AddAsync(ClienteRequest request)
        {

            using (var transaction = _clienteRepository.BeginTransactionAsync())
            {
                try
                {
                    // Lógica para adicionar o cliente
                    // 1. Validar o request
                    // 2. Obter o endereço pelo CEP usando _cepProvider
                    // 3. Mapear o request para a entidade Cliente
                    // 4. Salvar o cliente no repositório

                    var enderecoResponse = _cepProvider.GetAddressByCepAsync(request.Cep);

                    if (enderecoResponse == null)
                    {
                        transaction.Rollback();
                        return Task.FromResult(ResponseModel<ClienteDTO>.Failure("Erro ao obter o endereço pelo CEP: " + enderecoResponse.Result.ErrorMessage));
                    }

                } catch (Exception ex)
                {
                    transaction.Rollback();
                    return Task.FromResult(ResponseModel<ClienteDTO>.Failure("Erro ao adicionar o cliente: " + ex.Message));

                }
            }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ClienteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
