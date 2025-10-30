using DesafioMuralis2025.Application.Mappers;
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

        public async Task<ResponseModel<ClienteDTO>> AddAsync(CreateClienteRequest request)
        {

            var enderecoResponse = await _cepProvider.GetAddressByCepAsync(request.Endereco.Cep);
            if (enderecoResponse == null)
                return ResponseModel<ClienteDTO>.Failure("Endereço não encontrado para o CEP informado.");

            var endereco = new EnderecoModel
            (
                enderecoResponse.Cep,
                enderecoResponse.Logradouro,
                enderecoResponse.Cidade,
                request.Endereco.Numero,
                request.Endereco.Complemento
            );

            var novoCliente = new ClienteModel
            (
                request.Nome,
                endereco,
                request.Contatos.Select(c => new ContatoModel(c.Tipo, c.Texto)).ToList()
            );

            await using (var transaction = await _clienteRepository.BeginTransactionAsync())
            {
                try
                {
                    await _clienteRepository.AddAsync(novoCliente);

                    await _clienteRepository.CommitAsync();

                    await transaction.CommitAsync();

                    var clienteDto = new ClienteDTO
                    (
                        novoCliente.Id,
                        novoCliente.Nome,
                        novoCliente.DataCadastro,
                        novoCliente.Endereco.ToMapEndereco(), 
                        novoCliente.Contatos.Select(c => new ContatoDTO(c.Tipo, c.Texto)).ToList()
                    );

                    return ResponseModel<ClienteDTO>.Success(clienteDto);

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return await Task.FromResult(ResponseModel<ClienteDTO>.Failure("Erro ao adicionar o cliente: " + ex.Message));

                }
            }


        }


        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            await _clienteRepository.CommitAsync();
        }

        public async Task<ResponseModel<List<ClienteDTO>>> GetAll()
        {
            var lista = await _clienteRepository.GetAll();
            if(lista == null || !lista.Any())
                return ResponseModel<List<ClienteDTO>>.Failure("Nenhum cliente encontrado.");

            return ResponseModel<List<ClienteDTO>>.Success(lista.Select(c => c.ToMapClienteDTO()).ToList());
        }

        public async Task<ResponseModel<ClienteDTO>> GetById(int id)
        {
            var cliente = await _clienteRepository.GetById(id);
            if(cliente == null)
                return ResponseModel<ClienteDTO>.Failure("Cliente não encontrado.");

            return ResponseModel<ClienteDTO>.Success(cliente.ToMapClienteDTO());
        }

        public async Task<ResponseModel<ClienteDTO>> UpdateAsync(UpdateClienteRequest request)
        {
            await using(var transaction = await _clienteRepository.BeginTransactionAsync())
            {
                try
                {
                    var clienteExistente = await _clienteRepository.GetById(request.Id);
                    if (clienteExistente == null)
                        return ResponseModel<ClienteDTO>.Failure("Cliente não encontrado.");

                    clienteExistente.UpdateNome(request.Nome);

                    var enderecoResponse = await _cepProvider.GetAddressByCepAsync(request.Endereco.Cep);
                    if (enderecoResponse == null)
                        return ResponseModel<ClienteDTO>.Failure("Endereço não encontrado para o CEP informado.");

                    var enderecoAtualizado = new EnderecoModel(
                        enderecoResponse.Cep,
                        enderecoResponse.Logradouro,
                        enderecoResponse.Cidade,
                        request.Endereco.Numero,
                        request.Endereco.Complemento ?? string.Empty
                        );

                    clienteExistente.UpdateEndereco(enderecoAtualizado);

                    clienteExistente.UpdateContatos(
                            request.Contatos.Select(c => new ContatoModel(c.Tipo, c.Texto)).ToList()
                    );

                    await _clienteRepository.UpdateAsync(clienteExistente);
                    await _clienteRepository.CommitAsync();
                    await transaction.CommitAsync();

                    return ResponseModel<ClienteDTO>.Success(clienteExistente.ToMapClienteDTO());

                }catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    return ResponseModel<ClienteDTO>.Failure("Erro ao atualizar o cliente: " + ex.Message);
                }
            }
        }
    }
}
