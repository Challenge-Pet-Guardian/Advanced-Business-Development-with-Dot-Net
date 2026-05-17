using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record TipoAtendRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string Tipo)
{
    public TipoAtend ToDomain() => new(Tipo);
}