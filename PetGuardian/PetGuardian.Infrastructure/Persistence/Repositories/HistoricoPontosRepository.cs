using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Repositories;

public sealed class HistoricoPontosRepository(PetGuardianContext context)
    : Repository<HistoricoPontos>(context), IHistoricoPontosRepository
{
    public IReadOnlyList<HistoricoPontos> GetByUsuarioId(Guid usuarioId) =>
        Context.HistoricoPontos.AsNoTracking()
            .Where(h => h.UsuarioId == usuarioId)
            .OrderByDescending(h => h.DataConclusao)
            .ToList();

    public IReadOnlyList<HistoricoPontos> GetByTarefaId(Guid tarefaId) =>
        Context.HistoricoPontos.AsNoTracking()
            .Where(h => h.TarefaId == tarefaId)
            .OrderByDescending(h => h.DataConclusao)
            .ToList();
}