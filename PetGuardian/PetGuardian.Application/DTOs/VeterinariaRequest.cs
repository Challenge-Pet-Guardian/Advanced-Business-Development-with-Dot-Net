using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record VeterinariaRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string Nome,
    [property: Required] Guid EnderecoId,
    [property: Required] Guid TelefoneId)
{
    public Veterinaria ToDomain() => new(Nome, EnderecoId, TelefoneId);
}