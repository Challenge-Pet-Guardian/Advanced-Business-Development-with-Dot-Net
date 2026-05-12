using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para família.
/// </summary>
public record FamiliaResponse(Guid Id, string Nome)
{
    /// <summary>Mapeia <see cref="Familia"/> para DTO.</summary>
    public static FamiliaResponse FromDomain(Familia f) => new(f.Id, f.Nome);
}