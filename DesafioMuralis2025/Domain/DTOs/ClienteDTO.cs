namespace DesafioMuralis2025.Domain.DTOs
{
    public record class ClienteDTO
    (
        int Id,
        string Nome,
        DateOnly DataCadastro,
        EnderecoDTO Endereco,
        List<ContatoDTO> Contatos
    );
}
