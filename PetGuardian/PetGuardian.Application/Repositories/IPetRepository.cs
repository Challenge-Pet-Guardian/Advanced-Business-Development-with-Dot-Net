using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Repositories;

/// <summary>
/// Contrato de persistência para <see cref="Pet"/>.
/// </summary>
public interface IPetRepository : IRepository<Pet>
{
    /// <summary>Lista todos os pets pertencentes a uma família.</summary>
    IReadOnlyList<Pet> GetByFamiliaId(Guid familiaId);
}