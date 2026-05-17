using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record UsuarioRequest(
    [property: Required][property: StringLength(100, MinimumLength = 2)] string Nome,
    [property: Required][property: EmailAddress][property: StringLength(50)] string Email,
    [property: Required][property: StringLength(20, MinimumLength = 6)] string Senha,
    [property: Required] Guid EnderecoId,
    [property: Required] Guid FamiliaId,
    [property: Required] Guid TelefoneId)
{
    public Usuario ToDomain() => new(Nome, Email, Senha, EnderecoId, FamiliaId, TelefoneId);
}