using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class TarefaService(
    ITarefaRepository tarefaRepository,
    IPetRepository petRepository,
    IUsuarioRepository usuarioRepository,
    IRepository<Status> statusRepository) : ITarefaService
{
    public IReadOnlyList<TarefaResponse> GetAll() =>
        tarefaRepository.GetAll().Select(TarefaResponse.FromDomain).ToList();

    public TarefaResponse? GetById(Guid id)
    {
        var t = tarefaRepository.GetById(id);
        return t is null ? null : TarefaResponse.FromDomain(t);
    }

    public IReadOnlyList<TarefaResponse> GetByPetId(Guid petId) =>
        tarefaRepository.GetByPetId(petId).Select(TarefaResponse.FromDomain).ToList();

    public IReadOnlyList<TarefaResponse> GetByUsuarioId(Guid usuarioId) =>
        tarefaRepository.GetByUsuarioId(usuarioId).Select(TarefaResponse.FromDomain).ToList();

    public IReadOnlyList<TarefaResponse> GetByStatusId(Guid statusId) =>
        tarefaRepository.GetByStatusId(statusId).Select(TarefaResponse.FromDomain).ToList();

    public TarefaResponse Create(TarefaRequest request)
    {
        if (!petRepository.ExistsById(request.PetId))
            throw new InvalidOperationException("Pet não encontrado.");

        if (!usuarioRepository.ExistsById(request.UsuarioId))
            throw new InvalidOperationException("Usuário não encontrado.");

        if (!statusRepository.ExistsById(request.StatusId))
            throw new InvalidOperationException("Status não encontrado.");

        var tarefa = request.ToDomain();
        tarefaRepository.Add(tarefa);
        return TarefaResponse.FromDomain(tarefa);
    }

    public bool Delete(Guid id) => tarefaRepository.Delete(id);
}