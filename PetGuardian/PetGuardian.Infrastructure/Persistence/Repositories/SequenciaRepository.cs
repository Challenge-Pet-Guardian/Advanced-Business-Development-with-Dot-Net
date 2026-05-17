using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Repositories;

public sealed class SequenciaRepository(PetGuardianContext context)
    : Repository<Sequencia>(context), ISequenciaRepository
{
    public Sequencia? GetByFamiliaId(Guid familiaId) =>
        Context.Sequencias.AsNoTracking().FirstOrDefault(s => s.FamiliaId == familiaId);

    public bool ExistsForFamilia(Guid familiaId) =>
        Context.Sequencias.Any(s => s.FamiliaId == familiaId);
}