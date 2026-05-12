using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Domain.Entities;
using PetGuardian.Infrastructure.Persistence;

namespace PetGuardian.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF Core de <see cref="IPetRepository"/>.
/// </summary>
public sealed class PetRepository(PetGuardianContext context)
    : Repository<Pet>(context), IPetRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Pet> GetByFamiliaId(Guid familiaId)
    {
        return Context.Pets
            .AsNoTracking()
            .Where(p => p.FamiliaId == familiaId)
            .OrderBy(p => p.Nome)
            .ToList();
    }
}