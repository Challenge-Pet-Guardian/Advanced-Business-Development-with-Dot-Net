using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de família.
/// </summary>
public record FamiliaRequest(
    [property: Required(ErrorMessage = "O nome da família é obrigatório")]
    [property: StringLength(30, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 30 caracteres")]
    string Nome)
{
    /// <summary>Constrói a entidade <see cref="Familia"/>.</summary>
    public Familia ToDomain() => new(Nome);
}