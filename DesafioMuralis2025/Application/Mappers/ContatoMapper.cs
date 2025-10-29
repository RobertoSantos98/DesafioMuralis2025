using DesafioMuralis2025.Domain.DTOs;
using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Application.Mappers
{
    public static class ContatoMapper
    {
        public static ContatoDTO ToMapContato(this ContatoModel contato)
        {
            return new ContatoDTO(
                contato.Id,
                contato.Tipo ?? string.Empty,
                contato.Texto ?? string.Empty
            );
        }
    }
}
