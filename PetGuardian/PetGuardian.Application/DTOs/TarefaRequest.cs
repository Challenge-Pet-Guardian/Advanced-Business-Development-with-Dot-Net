using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de tarefa.
/// Status inicial é sempre <see cref="PetGuardian.Domain.Enums.StatusTarefa.Pendente"/> — definido no domínio.
/// </summary>
public record TarefaRequest(
    [property: Required(ErrorMessage = "O título é obrigatório")]
    [property: StringLength(30, MinimumLength = 2, ErrorMessage = "O título deve ter entre 2 e 30 caracteres")]
    string Titulo,

    [property: Required(ErrorMessage = "A descrição é obrigatória")]
    [property: StringLength(200, MinimumLength = 2, ErrorMessage = "A descrição deve ter entre 2 e 200 caracteres")]
    string Descricao,

    [property: Required(ErrorMessage = "O prazo é obrigatório")]
    DateTime Prazo,

    [property: Required(ErrorMessage = "O id do usuário responsável é obrigatório")]
    Guid UsuarioId,

    [property: Required(ErrorMessage = "O id do pet é obrigatório")]
    Guid PetId,

    [property: Required(ErrorMessage = "O id da família é obrigatório")]
    Guid FamiliaId)
{
    /// <summary>Constrói a entidade <see cref="Tarefa"/>.</summary>
    public Tarefa ToDomain() => new(Titulo, Descricao, Prazo, UsuarioId, PetId, FamiliaId);
}