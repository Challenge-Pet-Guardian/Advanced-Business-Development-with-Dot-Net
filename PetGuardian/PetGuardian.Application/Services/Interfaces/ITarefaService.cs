using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de tarefa de cuidado.
/// </summary>
public interface ITarefaService
{
    IReadOnlyList<TarefaResponse> GetAll();

    TarefaResponse? GetById(Guid id);

    IReadOnlyList<TarefaResponse> GetByPetId(Guid petId);

    IReadOnlyList<TarefaResponse> GetByUsuarioId(Guid usuarioId);

    IReadOnlyList<TarefaResponse> GetByFamiliaId(Guid familiaId);

    TarefaResponse Create(TarefaRequest request);

    bool Delete(Guid id);
}