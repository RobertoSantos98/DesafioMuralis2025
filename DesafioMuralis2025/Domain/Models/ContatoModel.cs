namespace DesafioMuralis2025.Domain.Models
{
    public class ContatoModel
    {
        public int Id { get; private set; }
        public string? Tipo { get; private set; }
        public string? Texto { get; private set; }

        public int ClienteId { get; private set; }
        public ClienteModel? Cliente { get; private set; }


        private ContatoModel() { }
       
    }
}
