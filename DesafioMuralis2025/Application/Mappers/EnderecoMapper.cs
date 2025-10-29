using DesafioMuralis2025.Domain.DTOs;
using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Application.Mappers
{
    public static class EnderecoMapper
    {
        public static EnderecoDTO ToMapEndereco(this EnderecoModel endereco)
        {
            return new EnderecoDTO
            (
                endereco.Cep,
                endereco.Logradouro,
                endereco.Cidade,
                endereco.Numero,
                endereco.Complemento
            );
        }
    }
}
