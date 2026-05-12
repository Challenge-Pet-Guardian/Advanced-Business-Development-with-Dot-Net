using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de usuário.
/// </summary>
/// <remarks>
/// O endereço e a família devem ser criados previamente.
/// A senha é recebida em texto e validada no domínio.
/// </remarks>
public record UsuarioRequest(
    [property: Required(ErrorMessage = "O nome é obrigatório")]
    [property: StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,

    [property: Required(ErrorMessage = "O e-mail é obrigatório")]
    [property: EmailAddress(ErrorMessage = "E-mail inválido")]
    [property: StringLength(50, ErrorMessage = "O e-mail deve ter no máximo 50 caracteres")]
    string Email,

    [property: Required(ErrorMessage = "A senha é obrigatória")]
    [property: StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caracteres")]
    string Senha,

    [property: Required(ErrorMessage = "O telefone é obrigatório")]
    [property: StringLength(11, MinimumLength = 10, ErrorMessage = "O telefone deve ter entre 10 e 11 dígitos")]
    string Telefone,

    [property: Required(ErrorMessage = "O id da família é obrigatório")]
    Guid FamiliaId,

    [property: Required(ErrorMessage = "O id do endereço é obrigatório")]
    Guid EnderecoId)
{
    /// <summary>Constrói a entidade <see cref="Usuario"/>.</summary>
    public Usuario ToDomain() => new(Nome, Email, Senha, Telefone, FamiliaId, EnderecoId);
}