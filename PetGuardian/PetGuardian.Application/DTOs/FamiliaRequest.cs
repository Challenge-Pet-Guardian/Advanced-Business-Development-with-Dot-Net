using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record FamiliaRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)]
    string NomeFamilia)
{
    public Familia ToDomain() => new(NomeFamilia);
}