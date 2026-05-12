using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de veterinária.
/// </summary>
public sealed class VeterinariaService(
    IRepository<Veterinaria> veterinariaRepository,
    IRepository<Endereco> enderecoRepository) : IVeterinariaService
{
    /// <inheritdoc />
    public IReadOnlyList<VeterinariaResponse> GetAll()
    {
        return veterinariaRepository.GetAll()
            .Select(VeterinariaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public VeterinariaResponse? GetById(Guid id)
    {
        var veterinaria = veterinariaRepository.GetById(id);
        return veterinaria is null ? null : VeterinariaResponse.FromDomain(veterinaria);
    }

    /// <inheritdoc />
    public VeterinariaResponse Create(VeterinariaRequest request)
    {
        if (veterinariaRepository.ExistsByNome(request.Nome))
            throw new InvalidOperationException("Já existe uma veterinária com este nome.");

        if (!enderecoRepository.ExistsById(request.EnderecoId))
            throw new InvalidOperationException("Endereço não encontrado.");

        var veterinaria = request.ToDomain();
        veterinariaRepository.Add(veterinaria);
        return VeterinariaResponse.FromDomain(veterinaria);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return veterinariaRepository.Delete(id);
    }
}