using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de família.
/// </summary>
public sealed class FamiliaService(IRepository<Familia> familiaRepository) : IFamiliaService
{
    /// <inheritdoc />
    public IReadOnlyList<FamiliaResponse> GetAll()
    {
        return familiaRepository.GetAll()
            .Select(FamiliaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public FamiliaResponse? GetById(Guid id)
    {
        var familia = familiaRepository.GetById(id);
        return familia is null ? null : FamiliaResponse.FromDomain(familia);
    }

    /// <inheritdoc />
    public FamiliaResponse Create(FamiliaRequest request)
    {
        if (familiaRepository.ExistsByNome(request.Nome))
            throw new InvalidOperationException("Já existe uma família com este nome.");

        var familia = request.ToDomain();
        familiaRepository.Add(familia);
        return FamiliaResponse.FromDomain(familia);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return familiaRepository.Delete(id);
    }
}