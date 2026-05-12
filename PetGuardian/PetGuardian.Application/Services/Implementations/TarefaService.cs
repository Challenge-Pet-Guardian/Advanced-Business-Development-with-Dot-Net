using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de tarefa de cuidado.
/// </summary>
public sealed class TarefaService(
    ITarefaRepository tarefaRepository,
    IPetRepository petRepository,
    IUsuarioRepository usuarioRepository,
    IRepository<Familia> familiaRepository) : ITarefaService
{
    /// <inheritdoc />
    public IReadOnlyList<TarefaResponse> GetAll()
    {
        return tarefaRepository.GetAll()
            .Select(TarefaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public TarefaResponse? GetById(Guid id)
    {
        var tarefa = tarefaRepository.GetById(id);
        return tarefa is null ? null : TarefaResponse.FromDomain(tarefa);
    }

    /// <inheritdoc />
    public IReadOnlyList<TarefaResponse> GetByPetId(Guid petId)
    {
        return tarefaRepository.GetByPetId(petId)
            .Select(TarefaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<TarefaResponse> GetByUsuarioId(Guid usuarioId)
    {
        return tarefaRepository.GetByUsuarioId(usuarioId)
            .Select(TarefaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<TarefaResponse> GetByFamiliaId(Guid familiaId)
    {
        return tarefaRepository.GetByFamiliaId(familiaId)
            .Select(TarefaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public TarefaResponse Create(TarefaRequest request)
    {
        if (!usuarioRepository.ExistsById(request.UsuarioId))
            throw new InvalidOperationException("Usuário não encontrado.");

        if (!petRepository.ExistsById(request.PetId))
            throw new InvalidOperationException("Pet não encontrado.");

        if (!familiaRepository.ExistsById(request.FamiliaId))
            throw new InvalidOperationException("Família não encontrada.");

        var tarefa = request.ToDomain();
        tarefaRepository.Add(tarefa);
        return TarefaResponse.FromDomain(tarefa);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return tarefaRepository.Delete(id);
    }
}