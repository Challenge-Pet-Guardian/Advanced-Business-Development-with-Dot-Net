using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de usuário.
/// </summary>
public sealed class UsuarioService(
    IUsuarioRepository usuarioRepository,
    IRepository<Familia> familiaRepository,
    IRepository<Endereco> enderecoRepository) : IUsuarioService
{
    /// <inheritdoc />
    public IReadOnlyList<UsuarioResponse> GetAll()
    {
        return usuarioRepository.GetAll()
            .Select(UsuarioResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public UsuarioResponse? GetById(Guid id)
    {
        var usuario = usuarioRepository.GetById(id);
        return usuario is null ? null : UsuarioResponse.FromDomain(usuario);
    }

    /// <inheritdoc />
    public UsuarioResponse? GetByEmail(string email)
    {
        var usuario = usuarioRepository.GetByEmail(email);
        return usuario is null ? null : UsuarioResponse.FromDomain(usuario);
    }

    /// <inheritdoc />
    public UsuarioResponse Create(UsuarioRequest request)
    {
        if (usuarioRepository.ExistsByEmail(request.Email))
            throw new InvalidOperationException("Já existe um usuário com este e-mail.");

        if (!familiaRepository.ExistsById(request.FamiliaId))
            throw new InvalidOperationException("Família não encontrada.");

        if (!enderecoRepository.ExistsById(request.EnderecoId))
            throw new InvalidOperationException("Endereço não encontrado.");

        var usuario = request.ToDomain();
        usuarioRepository.Add(usuario);
        return UsuarioResponse.FromDomain(usuario);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return usuarioRepository.Delete(id);
    }
}