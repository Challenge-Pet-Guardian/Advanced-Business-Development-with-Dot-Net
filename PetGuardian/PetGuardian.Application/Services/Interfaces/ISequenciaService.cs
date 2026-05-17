using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

public interface ISequenciaService
{
    IReadOnlyList<SequenciaResponse> GetAll();
    SequenciaResponse? GetById(Guid id);
    SequenciaResponse? GetByFamiliaId(Guid familiaId);
    SequenciaResponse Create(Guid familiaId);
    bool Delete(Guid id);
}