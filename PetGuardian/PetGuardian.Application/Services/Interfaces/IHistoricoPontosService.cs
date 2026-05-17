using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

public interface IHistoricoPontosService
{
    IReadOnlyList<HistoricoPontosResponse> GetAll();
    HistoricoPontosResponse? GetById(Guid id);
    IReadOnlyList<HistoricoPontosResponse> GetByUsuarioId(Guid usuarioId);
    IReadOnlyList<HistoricoPontosResponse> GetByTarefaId(Guid tarefaId);
    HistoricoPontosResponse Create(HistoricoPontosRequest request);
    bool Delete(Guid id);
}