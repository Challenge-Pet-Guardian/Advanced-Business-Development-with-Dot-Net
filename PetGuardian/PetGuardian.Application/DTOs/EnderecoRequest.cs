using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record EnderecoRequest(
    [property: Required][property: StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter 8 dígitos")]
    string Cep,
    [property: Required][property: StringLength(200, MinimumLength = 2)]
    string Rua,
    [property: Required] Guid BairroId)
{
    public Endereco ToDomain() => new(Cep, Rua, BairroId);
}