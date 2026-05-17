using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record TarefaRequest(
    [property: Required][property: StringLength(30, MinimumLength = 2)] string Titulo,
    [property: Range(0, 999)] int PontosTarefa,
    [property: Required][property: StringLength(200, MinimumLength = 2)] string Descricao,
    [property: Required] DateTime Prazo,
    [property: Required] Guid PetId,
    [property: Required] Guid UsuarioId,
    [property: Required] Guid StatusId)
{
    public Tarefa ToDomain() => new(Titulo, PontosTarefa, Descricao, Prazo, PetId, UsuarioId, StatusId);
}