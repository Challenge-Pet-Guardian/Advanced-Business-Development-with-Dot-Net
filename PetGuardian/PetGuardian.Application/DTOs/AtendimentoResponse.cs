using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record AtendimentoResponse(
    Guid Id, DateTime Data, string Anotacoes, decimal Valor,
    Guid PetId, Guid VeterinariaId, Guid TipoAtendId, Guid StatusId)
{
    public static AtendimentoResponse FromDomain(Atendimento a) =>
        new(a.Id, a.Data, a.Anotacoes, a.Valor, a.PetId, a.VeterinariaId, a.TipoAtendId, a.StatusId);
}