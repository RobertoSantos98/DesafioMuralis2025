using DesafioMuralis2025.Domain.DTOs;
using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Application.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteDTO ToMapClienteDTO(this ClienteModel cliente)
        {
            return new ClienteDTO
            (
                cliente.Id,
                cliente.Nome,
                cliente.DataCadastro,
                cliente.Endereco.ToMapEndereco(),
                cliente.Contatos.Select(c => c.ToMapContato()).ToList()
            );

        }
    }
}
