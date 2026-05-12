using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de endereço.
/// </summary>
public record EnderecoRequest(
    [property: Required(ErrorMessage = "A rua é obrigatória")]
    [property: StringLength(100, MinimumLength = 2, ErrorMessage = "A rua deve ter entre 2 e 100 caracteres")]
    string Rua,

    [property: Required(ErrorMessage = "O bairro é obrigatório")]
    [property: StringLength(50, MinimumLength = 2, ErrorMessage = "O bairro deve ter entre 2 e 50 caracteres")]
    string Bairro,

    [property: Required(ErrorMessage = "A cidade é obrigatória")]
    [property: StringLength(50, MinimumLength = 2, ErrorMessage = "A cidade deve ter entre 2 e 50 caracteres")]
    string Cidade,

    [property: Required(ErrorMessage = "O estado é obrigatório")]
    [property: StringLength(50, MinimumLength = 2, ErrorMessage = "O estado deve ter entre 2 e 50 caracteres")]
    string Estado)
{
    /// <summary>Constrói a entidade <see cref="Endereco"/>.</summary>
    public Endereco ToDomain() => new(Rua, Bairro, Cidade, Estado);
}