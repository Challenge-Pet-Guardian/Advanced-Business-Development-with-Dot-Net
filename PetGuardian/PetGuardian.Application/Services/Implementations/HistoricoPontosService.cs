using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.Application.Services.Implementations;

public sealed class HistoricoPontosService(
    IHistoricoPontosRepository historicoRepository,
    IUsuarioRepository usuarioRepository,
    ITarefaRepository tarefaRepository) : IHistoricoPontosService
{
    public IReadOnlyList<HistoricoPontosResponse> GetAll() =>
        historicoRepository.GetAll().Select(HistoricoPontosResponse.FromDomain).ToList();

    public HistoricoPontosResponse? GetById(Guid id)
    {
        var h = historicoRepository.GetById(id);
        return h is null ? null : HistoricoPontosResponse.FromDomain(h);
    }

    public IReadOnlyList<HistoricoPontosResponse> GetByUsuarioId(Guid usuarioId) =>
        historicoRepository.GetByUsuarioId(usuarioId).Select(HistoricoPontosResponse.FromDomain).ToList();

    public IReadOnlyList<HistoricoPontosResponse> GetByTarefaId(Guid tarefaId) =>
        historicoRepository.GetByTarefaId(tarefaId).Select(HistoricoPontosResponse.FromDomain).ToList();

    public HistoricoPontosResponse Create(HistoricoPontosRequest request)
    {
        if (!usuarioRepository.ExistsById(request.UsuarioId))
            throw new InvalidOperationException("Usuário não encontrado.");

        if (!tarefaRepository.ExistsById(request.TarefaId))
            throw new InvalidOperationException("Tarefa não encontrada.");

        var historico = request.ToDomain();
        historicoRepository.Add(historico);
        return HistoricoPontosResponse.FromDomain(historico);
    }

    public bool Delete(Guid id) => historicoRepository.Delete(id);
}