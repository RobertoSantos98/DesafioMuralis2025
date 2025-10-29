using System.Text.Json.Serialization;

namespace DesafioMuralis2025.Domain.DTOs
{
    public record class EnderecoDTO
    (
         string Cep,
         string Logradouro,
         string Cidade,
         string Numero,
         string Complemento
    );
}