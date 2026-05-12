using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de veterinária.
/// O endereço deve ser criado previamente.
/// </summary>
public record VeterinariaRequest(
    [property: Required(ErrorMessage = "O nome da veterinária é obrigatório")]
    [property: StringLength(30, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 30 caracteres")]
    string Nome,

    [property: Required(ErrorMessage = "O id do endereço é obrigatório")]
    Guid EnderecoId)
{
    /// <summary>Constrói a entidade <see cref="Veterinaria"/>.</summary>
    public Veterinaria ToDomain() => new(Nome, EnderecoId);
}