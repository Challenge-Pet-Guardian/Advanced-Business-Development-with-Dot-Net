using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para usuário (dados sensíveis como senha nunca são expostos).
/// </summary>
public record UsuarioResponse(
    Guid   Id,
    string Nome,
    string Email,
    string Telefone,
    Guid   FamiliaId,
    Guid   EnderecoId)
{
    /// <summary>Mapeia <see cref="Usuario"/> para DTO.</summary>
    public static UsuarioResponse FromDomain(Usuario u) =>
        new(u.Id, u.Nome, u.Email, u.Telefone, u.FamiliaId, u.EnderecoId);
}