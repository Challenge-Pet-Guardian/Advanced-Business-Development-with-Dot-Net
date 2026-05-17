using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record UsuarioPetRequest(
    [property: Required] Guid UsuarioId,
    [property: Required] Guid PetId,
    bool ResponPrinc)
{
    public UsuarioPet ToDomain() => new(UsuarioId, PetId, ResponPrinc);
}