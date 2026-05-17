using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Repositories;

public interface IPontosTotaisRepository : IRepository<PontosTotais>
{
    PontosTotais? GetByUsuarioId(Guid usuarioId);
    bool ExistsForUsuario(Guid usuarioId);
}