using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Domain.Entities;
using PetGuardian.Infrastructure.Persistence;

namespace PetGuardian.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF Core de <see cref="IAtendimentoRepository"/>.
/// </summary>
public sealed class AtendimentoRepository(PetGuardianContext context)
    : Repository<Atendimento>(context), IAtendimentoRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Atendimento> GetByPetId(Guid petId)
    {
        return Context.Atendimentos
            .AsNoTracking()
            .Where(a => a.PetId == petId)
            .OrderByDescending(a => a.Data)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<Atendimento> GetByVeterinariaId(Guid veterinariaId)
    {
        return Context.Atendimentos
            .AsNoTracking()
            .Where(a => a.VeterinariaId == veterinariaId)
            .OrderByDescending(a => a.Data)
            .ToList();
    }
}