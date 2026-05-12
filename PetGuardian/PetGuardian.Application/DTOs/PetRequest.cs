using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de pet.
/// </summary>
public record PetRequest(
    [property: Required(ErrorMessage = "O nome do pet é obrigatório")]
    [property: StringLength(30, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 30 caracteres")]
    string Nome,

    [property: Required(ErrorMessage = "A raça é obrigatória")]
    [property: StringLength(20, MinimumLength = 2, ErrorMessage = "A raça deve ter entre 2 e 20 caracteres")]
    string Raca,

    [property: Required(ErrorMessage = "O porte é obrigatório")]
    PortePet Porte,

    [property: Required(ErrorMessage = "O sexo é obrigatório")]
    SexoPet Sexo,

    [property: Range(0, 99, ErrorMessage = "A idade deve estar entre 0 e 99")]
    int Idade,

    bool Castrado,

    [property: Required(ErrorMessage = "O id da família é obrigatório")]
    Guid FamiliaId)
{
    /// <summary>Constrói a entidade <see cref="Pet"/>.</summary>
    public Pet ToDomain() => new(Nome, Raca, Porte, Sexo, Idade, Castrado, FamiliaId);
}