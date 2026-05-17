using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record SequenciaResponse(Guid Id, int SequenciaAtual, int SequenciaMaxima, DateTime DataUltimaAcao, Guid FamiliaId)
{
    public static SequenciaResponse FromDomain(Sequencia s) =>
        new(s.Id, s.SequenciaAtual, s.SequenciaMaxima, s.DataUltimaAcao, s.FamiliaId);
}