using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de usuário.
/// </summary>
public interface IUsuarioService
{
    IReadOnlyList<UsuarioResponse> GetAll();

    UsuarioResponse? GetById(Guid id);

    UsuarioResponse? GetByEmail(string email);

    UsuarioResponse Create(UsuarioRequest request);

    bool Delete(Guid id);
}