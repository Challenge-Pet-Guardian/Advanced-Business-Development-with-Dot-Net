using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class PetService(
    IPetRepository petRepository,
    IRepository<Raca> racaRepository) : IPetService
{
    public IReadOnlyList<PetResponse> GetAll() =>
        petRepository.GetAll().Select(PetResponse.FromDomain).ToList();

    public PetResponse? GetById(Guid id)
    {
        var pet = petRepository.GetById(id);
        return pet is null ? null : PetResponse.FromDomain(pet);
    }

    public IReadOnlyList<PetResponse> GetByRacaId(Guid racaId) =>
        petRepository.GetAll()
            .Where(p => p.RacaId == racaId)
            .Select(PetResponse.FromDomain)
            .ToList();

    public PetResponse Create(PetRequest request)
    {
        if (!racaRepository.ExistsById(request.RacaId))
            throw new InvalidOperationException("Raça não encontrada.");

        var pet = request.ToDomain();
        petRepository.Add(pet);
        return PetResponse.FromDomain(pet);
    }

    public bool Delete(Guid id) => petRepository.Delete(id);
}