namespace DesafioMuralis2025.Domain.Models
{
    public class EnderecoModel
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public int ClienteId { get; private set; }
        public virtual ClienteModel Cliente { get; private set; }

    }
}
