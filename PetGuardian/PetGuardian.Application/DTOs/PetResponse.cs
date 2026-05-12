using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para pet.
/// </summary>
public record PetResponse(
    Guid     Id,
    string   Nome,
    string   Raca,
    PortePet Porte,
    SexoPet  Sexo,
    int      Idade,
    bool     Castrado,
    Guid     FamiliaId)
{
    /// <summary>Mapeia <see cref="Pet"/> para DTO.</summary>
    public static PetResponse FromDomain(Pet p) =>
        new(p.Id, p.Nome, p.Raca, p.Porte, p.Sexo, p.Idade, p.Castrado, p.FamiliaId);
}