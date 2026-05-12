using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de pet.
/// </summary>
public interface IPetService
{
    IReadOnlyList<PetResponse> GetAll();

    PetResponse? GetById(Guid id);

    IReadOnlyList<PetResponse> GetByFamiliaId(Guid familiaId);

    PetResponse Create(PetRequest request);

    bool Delete(Guid id);
}