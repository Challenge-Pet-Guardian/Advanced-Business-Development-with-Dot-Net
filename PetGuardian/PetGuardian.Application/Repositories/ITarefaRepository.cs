using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Repositories;

/// <summary>
/// Contrato de persistência para <see cref="Tarefa"/>.
/// </summary>
public interface ITarefaRepository : IRepository<Tarefa>
{
    /// <summary>Lista tarefas associadas a um pet.</summary>
    IReadOnlyList<Tarefa> GetByPetId(Guid petId);

    /// <summary>Lista tarefas atribuídas a um usuário.</summary>
    IReadOnlyList<Tarefa> GetByUsuarioId(Guid usuarioId);

    /// <summary>Lista tarefas de uma família.</summary>
    IReadOnlyList<Tarefa> GetByFamiliaId(Guid familiaId);
}