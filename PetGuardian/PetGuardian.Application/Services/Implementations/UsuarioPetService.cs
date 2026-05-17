using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.Application.Services.Implementations;

public sealed class UsuarioPetService(
    IUsuarioPetRepository usuarioPetRepository,
    IUsuarioRepository usuarioRepository,
    IPetRepository petRepository) : IUsuarioPetService
{
    public IReadOnlyList<UsuarioPetResponse> GetAll() =>
        usuarioPetRepository.GetAll().Select(UsuarioPetResponse.FromDomain).ToList();

    public IReadOnlyList<UsuarioPetResponse> GetByUsuarioId(Guid usuarioId) =>
        usuarioPetRepository.GetByUsuarioId(usuarioId).Select(UsuarioPetResponse.FromDomain).ToList();

    public IReadOnlyList<UsuarioPetResponse> GetByPetId(Guid petId) =>
        usuarioPetRepository.GetByPetId(petId).Select(UsuarioPetResponse.FromDomain).ToList();

    public UsuarioPetResponse Create(UsuarioPetRequest request)
    {
        if (!usuarioRepository.ExistsById(request.UsuarioId))
            throw new InvalidOperationException("Usuário não encontrado.");

        if (!petRepository.ExistsById(request.PetId))
            throw new InvalidOperationException("Pet não encontrado.");

        if (usuarioPetRepository.Exists(request.UsuarioId, request.PetId))
            throw new InvalidOperationException("Este usuário já está vinculado a este pet.");

        var vinculo = request.ToDomain();
        usuarioPetRepository.Add(vinculo);
        return UsuarioPetResponse.FromDomain(vinculo);
    }

    public bool Delete(Guid usuarioId, Guid petId) =>
        usuarioPetRepository.Delete(usuarioId, petId);
}