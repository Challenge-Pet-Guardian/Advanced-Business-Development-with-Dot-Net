using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de família.
/// </summary>
public interface IFamiliaService
{
    IReadOnlyList<FamiliaResponse> GetAll();

    FamiliaResponse? GetById(Guid id);

    FamiliaResponse Create(FamiliaRequest request);

    bool Delete(Guid id);
}