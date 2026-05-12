using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Domain.Entities;
using PetGuardian.Infrastructure.Persistence;

namespace PetGuardian.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF Core de <see cref="ITarefaRepository"/>.
/// </summary>
public sealed class TarefaRepository(PetGuardianContext context)
    : Repository<Tarefa>(context), ITarefaRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Tarefa> GetByPetId(Guid petId)
    {
        return Context.Tarefas
            .AsNoTracking()
            .Where(t => t.PetId == petId)
            .OrderBy(t => t.Prazo)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<Tarefa> GetByUsuarioId(Guid usuarioId)
    {
        return Context.Tarefas
            .AsNoTracking()
            .Where(t => t.UsuarioId == usuarioId)
            .OrderBy(t => t.Prazo)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<Tarefa> GetByFamiliaId(Guid familiaId)
    {
        return Context.Tarefas
            .AsNoTracking()
            .Where(t => t.FamiliaId == familiaId)
            .OrderBy(t => t.Prazo)
            .ToList();
    }
}