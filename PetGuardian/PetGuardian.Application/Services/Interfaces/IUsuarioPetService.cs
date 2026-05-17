using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

public interface IUsuarioPetService
{
    IReadOnlyList<UsuarioPetResponse> GetAll();
    IReadOnlyList<UsuarioPetResponse> GetByUsuarioId(Guid usuarioId);
    IReadOnlyList<UsuarioPetResponse> GetByPetId(Guid petId);
    UsuarioPetResponse Create(UsuarioPetRequest request);
    bool Delete(Guid usuarioId, Guid petId);
}