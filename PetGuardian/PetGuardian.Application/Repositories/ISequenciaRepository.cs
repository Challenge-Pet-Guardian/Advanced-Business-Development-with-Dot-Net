using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Repositories;

public interface ISequenciaRepository : IRepository<Sequencia>
{
    Sequencia? GetByFamiliaId(Guid familiaId);
    bool ExistsForFamilia(Guid familiaId);
}