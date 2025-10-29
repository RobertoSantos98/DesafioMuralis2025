using DesafioMuralis2025.Application.Utils;
using DesafioMuralis2025.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioMuralis2025.Application.Request
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        public string? DataCadastro { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public List<ContatoModel> Contatos { get; set; } = new List<ContatoModel>();

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [CepValidation(ErrorMessage = "O CEP informado é inválido.")]
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string? Complemento { get; set; }
    }
}
