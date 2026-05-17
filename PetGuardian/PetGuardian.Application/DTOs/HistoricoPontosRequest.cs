using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record HistoricoPontosRequest(
    [property: Range(0, 999)] int PontosGanhos,
    [property: Required] Guid TarefaId,
    [property: Required] Guid UsuarioId)
{
    public HistoricoPontos ToDomain() => new(PontosGanhos, TarefaId, UsuarioId);
}