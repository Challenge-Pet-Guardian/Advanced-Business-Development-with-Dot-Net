using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para endereço.
/// </summary>
public record EnderecoResponse(
    Guid   Id,
    string Rua,
    string Bairro,
    string Cidade,
    string Estado)
{
    /// <summary>Mapeia <see cref="Endereco"/> para DTO.</summary>
    public static EnderecoResponse FromDomain(Endereco e) =>
        new(e.Id, e.Rua, e.Bairro, e.Cidade, e.Estado);
}