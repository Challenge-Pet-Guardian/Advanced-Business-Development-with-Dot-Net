using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

public interface IVeterinariaService
{
    IReadOnlyList<VeterinariaResponse> GetAll();
    VeterinariaResponse? GetById(Guid id);
    VeterinariaResponse Create(VeterinariaRequest request);
    bool Delete(Guid id);
}