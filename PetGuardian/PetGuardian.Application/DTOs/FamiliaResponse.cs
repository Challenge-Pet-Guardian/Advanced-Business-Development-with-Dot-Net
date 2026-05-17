using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record FamiliaResponse(Guid Id, string NomeFamilia)
{
    public static FamiliaResponse FromDomain(Familia f) => new(f.Id, f.NomeFamilia);
}