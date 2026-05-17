using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class FamiliaService(IRepository<Familia> familiaRepository) : IFamiliaService
{
    public IReadOnlyList<FamiliaResponse> GetAll() =>
        familiaRepository.GetAll().Select(FamiliaResponse.FromDomain).ToList();

    public FamiliaResponse? GetById(Guid id)
    {
        var familia = familiaRepository.GetById(id);
        return familia is null ? null : FamiliaResponse.FromDomain(familia);
    }

    public FamiliaResponse Create(FamiliaRequest request)
    {
        var familia = request.ToDomain();
        familiaRepository.Add(familia);
        return FamiliaResponse.FromDomain(familia);
    }

    public bool Delete(Guid id) => familiaRepository.Delete(id);
}