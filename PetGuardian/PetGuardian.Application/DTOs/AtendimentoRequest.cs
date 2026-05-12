using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de atendimento.
/// Status inicial é sempre <see cref="StatusAtendimento.Agendado"/> — definido no domínio.
/// </summary>
public record AtendimentoRequest(
    [property: Required(ErrorMessage = "O tipo de atendimento é obrigatório")]
    TipoAtendimento TipoAtendimento,

    [property: Required(ErrorMessage = "A data do atendimento é obrigatória")]
    DateTime Data,

    [property: Required(ErrorMessage = "As anotações são obrigatórias")]
    [property: StringLength(300, MinimumLength = 2, ErrorMessage = "As anotações devem ter entre 2 e 300 caracteres")]
    string Anotacoes,

    [property: Range(0, 99999.99, ErrorMessage = "O valor deve ser entre 0 e 99.999,99")]
    decimal Valor,

    [property: Required(ErrorMessage = "O id da veterinária é obrigatório")]
    Guid VeterinariaId,

    [property: Required(ErrorMessage = "O id do pet é obrigatório")]
    Guid PetId)
{
    /// <summary>Constrói a entidade <see cref="Atendimento"/>.</summary>
    public Atendimento ToDomain() =>
        new(TipoAtendimento, Data, Anotacoes, Valor, VeterinariaId, PetId);
}