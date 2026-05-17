using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record BairroRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string NomeBairro,
    [property: Required] Guid CidadeId)
{
    public Bairro ToDomain() => new(NomeBairro, CidadeId);
}