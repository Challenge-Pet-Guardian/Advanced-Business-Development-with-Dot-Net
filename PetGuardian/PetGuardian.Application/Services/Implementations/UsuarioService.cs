using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class UsuarioService(
    IUsuarioRepository usuarioRepository,
    IRepository<Familia> familiaRepository,
    IRepository<Endereco> enderecoRepository,
    IRepository<Telefone> telefoneRepository) : IUsuarioService
{
    public IReadOnlyList<UsuarioResponse> GetAll() =>
        usuarioRepository.GetAll().Select(UsuarioResponse.FromDomain).ToList();

    public UsuarioResponse? GetById(Guid id)
    {
        var usuario = usuarioRepository.GetById(id);
        return usuario is null ? null : UsuarioResponse.FromDomain(usuario);
    }

    public UsuarioResponse? GetByEmail(string email)
    {
        var usuario = usuarioRepository.GetByEmail(email);
        return usuario is null ? null : UsuarioResponse.FromDomain(usuario);
    }

    public UsuarioResponse Create(UsuarioRequest request)
    {
        if (usuarioRepository.ExistsByEmail(request.Email))
            throw new InvalidOperationException("Já existe um usuário com este e-mail.");

        if (!familiaRepository.ExistsById(request.FamiliaId))
            throw new InvalidOperationException("Família não encontrada.");

        if (!enderecoRepository.ExistsById(request.EnderecoId))
            throw new InvalidOperationException("Endereço não encontrado.");

        if (!telefoneRepository.ExistsById(request.TelefoneId))
            throw new InvalidOperationException("Telefone não encontrado.");

        var usuario = request.ToDomain();
        usuarioRepository.Add(usuario);
        return UsuarioResponse.FromDomain(usuario);
    }

    public bool Delete(Guid id) => usuarioRepository.Delete(id);
}