using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record PontosTotaisResponse(Guid Id, int QtdPontos, Guid UsuarioId)
{
    public static PontosTotaisResponse FromDomain(PontosTotais p) => new(p.Id, p.QtdPontos, p.UsuarioId);
}