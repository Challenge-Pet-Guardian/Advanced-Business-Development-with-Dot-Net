using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Application.DTOs;

/// <summary>
/// DTO de resposta para tarefa.
/// </summary>
public record TarefaResponse(
    Guid        Id,
    string      Titulo,
    string      Descricao,
    DateTime    Criacao,
    DateTime    Prazo,
    StatusTarefa Status,
    Guid        UsuarioId,
    Guid        PetId,
    Guid        FamiliaId)
{
    /// <summary>Mapeia <see cref="Tarefa"/> para DTO.</summary>
    public static TarefaResponse FromDomain(Tarefa t) =>
        new(t.Id, t.Titulo, t.Descricao, t.Criacao, t.Prazo, t.Status, t.UsuarioId, t.PetId, t.FamiliaId);
}