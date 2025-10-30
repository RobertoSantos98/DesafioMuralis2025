using DesafioMuralis2025.Application.Utils;
using DesafioMuralis2025.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioMuralis2025.Application.Request
{
    public class CreateClienteRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        public List<CreateContatoRequest> Contatos { get; set; }
        public CreateEnderecoRequest Endereco { get; set; }
    }

    public class CreateEnderecoRequest
    {
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [CepValidation(ErrorMessage = "O CEP informado é inválido.")]
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
    }

    public class CreateContatoRequest
    {
        [Required(ErrorMessage = "O tipo de contato é obrigatório.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O valor do contato é obrigatório.")]
        public string Texto { get; set; }
    }
}
