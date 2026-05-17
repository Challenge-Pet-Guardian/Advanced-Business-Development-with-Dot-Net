using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record HistoricoPontosResponse(Guid Id, int PontosGanhos, DateTime DataConclusao, Guid TarefaId, Guid UsuarioId)
{
    public static HistoricoPontosResponse FromDomain(HistoricoPontos h) =>
        new(h.Id, h.PontosGanhos, h.DataConclusao, h.TarefaId, h.UsuarioId);
}