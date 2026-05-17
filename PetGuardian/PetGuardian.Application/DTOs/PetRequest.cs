using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Application.DTOs;

public record PetRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string Nome,
    [property: Range(0, 99)] int Idade,
    [property: Required] SexoPet Sexo,
    [property: Required] PortePet Porte,
    bool Castrado,
    [property: Required] Guid RacaId)
{
    public Pet ToDomain() => new(Nome, Idade, Sexo, Porte, Castrado, RacaId);
}