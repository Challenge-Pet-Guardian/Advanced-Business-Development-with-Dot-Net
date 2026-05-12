using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para atendimento.
/// </summary>
public record AtendimentoResponse(
    Guid             Id,
    TipoAtendimento  TipoAtendimento,
    DateTime         Data,
    string           Anotacoes,
    StatusAtendimento Status,
    decimal          Valor,
    Guid             VeterinariaId,
    Guid             PetId)
{
    /// <summary>Mapeia <see cref="Atendimento"/> para DTO.</summary>
    public static AtendimentoResponse FromDomain(Atendimento a) =>
        new(a.Id, a.TipoAtendimento, a.Data, a.Anotacoes, a.Status, a.Valor, a.VeterinariaId, a.PetId);
}