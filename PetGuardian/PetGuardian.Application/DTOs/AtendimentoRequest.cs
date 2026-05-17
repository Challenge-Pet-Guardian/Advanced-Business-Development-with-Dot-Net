using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record AtendimentoRequest(
    [property: Required] DateTime Data,
    [property: Required][property: StringLength(300, MinimumLength = 2)] string Anotacoes,
    [property: Range(0, 99999.99)] decimal Valor,
    [property: Required] Guid PetId,
    [property: Required] Guid VeterinariaId,
    [property: Required] Guid TipoAtendId,
    [property: Required] Guid StatusId)
{
    public Atendimento ToDomain() => new(Data, Anotacoes, Valor, PetId, VeterinariaId, TipoAtendId, StatusId);
}