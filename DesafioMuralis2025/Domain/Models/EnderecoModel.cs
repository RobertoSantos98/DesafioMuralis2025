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

        private EnderecoModel() { }

        public EnderecoModel(string cep, string logradouro, string cidade, string numero, string complemento)
        {
            Cep = cep;
            Logradouro = logradouro;
            Cidade = cidade ?? string.Empty;
            Numero = numero;
            Complemento = complemento ?? string.Empty;
        }

    }
}
