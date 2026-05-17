using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record RacaRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string NomeRaca)
{
    public Raca ToDomain() => new(NomeRaca);
}