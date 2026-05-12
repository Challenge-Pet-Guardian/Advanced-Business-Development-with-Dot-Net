using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para veterinária.
/// </summary>
public record VeterinariaResponse(Guid Id, string Nome, Guid EnderecoId)
{
    /// <summary>Mapeia <see cref="Veterinaria"/> para DTO.</summary>
    public static VeterinariaResponse FromDomain(Veterinaria v) =>
        new(v.Id, v.Nome, v.EnderecoId);
}