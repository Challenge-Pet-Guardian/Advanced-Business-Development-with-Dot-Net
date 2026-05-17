using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

public interface IPontosTotaisService
{
    IReadOnlyList<PontosTotaisResponse> GetAll();
    PontosTotaisResponse? GetById(Guid id);
    PontosTotaisResponse? GetByUsuarioId(Guid usuarioId);
    PontosTotaisResponse Create(Guid usuarioId);
    bool Delete(Guid id);
}