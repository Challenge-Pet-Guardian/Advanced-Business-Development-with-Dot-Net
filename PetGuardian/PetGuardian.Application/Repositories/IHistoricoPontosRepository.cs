using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Repositories;

public interface IHistoricoPontosRepository : IRepository<HistoricoPontos>
{
    IReadOnlyList<HistoricoPontos> GetByUsuarioId(Guid usuarioId);
    IReadOnlyList<HistoricoPontos> GetByTarefaId(Guid tarefaId);
}