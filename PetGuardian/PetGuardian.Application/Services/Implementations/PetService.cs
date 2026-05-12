using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de pet.
/// </summary>
public sealed class PetService(
    IPetRepository petRepository,
    IRepository<Familia> familiaRepository) : IPetService
{
    /// <inheritdoc />
    public IReadOnlyList<PetResponse> GetAll()
    {
        return petRepository.GetAll()
            .Select(PetResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public PetResponse? GetById(Guid id)
    {
        var pet = petRepository.GetById(id);
        return pet is null ? null : PetResponse.FromDomain(pet);
    }

    /// <inheritdoc />
    public IReadOnlyList<PetResponse> GetByFamiliaId(Guid familiaId)
    {
        return petRepository.GetByFamiliaId(familiaId)
            .Select(PetResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public PetResponse Create(PetRequest request)
    {
        if (!familiaRepository.ExistsById(request.FamiliaId))
            throw new InvalidOperationException("Família não encontrada.");

        var pet = request.ToDomain();
        petRepository.Add(pet);
        return PetResponse.FromDomain(pet);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return petRepository.Delete(id);
    }
}