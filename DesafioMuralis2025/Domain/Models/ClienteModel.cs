namespace DesafioMuralis2025.Domain.Models
{
    public class ClienteModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateOnly DataCadastro { get; private set; } = DateOnly.FromDateTime(DateTime.Now);

        public virtual EnderecoModel Endereco { get; private set; }

        public virtual ICollection<ContatoModel> Contatos { get; private set; }

        public ClienteModel()
        {
            Contatos = new HashSet<ContatoModel>();
        }

        public ClienteModel(string nome, EnderecoModel endereco, ICollection<ContatoModel> contatos)
        {
            Nome = nome;
            Endereco = endereco;
            Contatos = contatos;
        }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public void UpdateEndereco(EnderecoModel endereco)
        {
            Endereco = endereco;
        }

        public void UpdateContatos(ICollection<ContatoModel> contatos)
        {
            Contatos = contatos;
        }

    }
}
