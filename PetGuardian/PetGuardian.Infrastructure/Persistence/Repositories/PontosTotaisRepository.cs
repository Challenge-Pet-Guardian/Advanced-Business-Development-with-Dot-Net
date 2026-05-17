using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Repositories;

public sealed class PontosTotaisRepository(PetGuardianContext context)
    : Repository<PontosTotais>(context), IPontosTotaisRepository
{
    public PontosTotais? GetByUsuarioId(Guid usuarioId) =>
        Context.PontosTotais.AsNoTracking().FirstOrDefault(p => p.UsuarioId == usuarioId);

    public bool ExistsForUsuario(Guid usuarioId) =>
        Context.PontosTotais.Any(p => p.UsuarioId == usuarioId);
}