using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record CidadeRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string NomeCidade,
    [property: Required] Guid EstadoId)
{
    public Cidade ToDomain() => new(NomeCidade, EstadoId);
}