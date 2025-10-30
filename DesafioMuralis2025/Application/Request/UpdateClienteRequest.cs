namespace DesafioMuralis2025.Application.Request
{
    public class UpdateClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CreateEnderecoRequest Endereco { get; set; }
        public List<CreateContatoRequest> Contatos { get; set; }
    }
}
