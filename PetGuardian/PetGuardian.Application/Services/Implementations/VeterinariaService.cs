using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class VeterinariaService(
    IRepository<Veterinaria> veterinariaRepository,
    IRepository<Endereco> enderecoRepository,
    IRepository<Telefone> telefoneRepository) : IVeterinariaService
{
    public IReadOnlyList<VeterinariaResponse> GetAll() =>
        veterinariaRepository.GetAll().Select(VeterinariaResponse.FromDomain).ToList();

    public VeterinariaResponse? GetById(Guid id)
    {
        var vet = veterinariaRepository.GetById(id);
        return vet is null ? null : VeterinariaResponse.FromDomain(vet);
    }

    public VeterinariaResponse Create(VeterinariaRequest request)
    {
        if (!enderecoRepository.ExistsById(request.EnderecoId))
            throw new InvalidOperationException("Endereço não encontrado.");

        if (!telefoneRepository.ExistsById(request.TelefoneId))
            throw new InvalidOperationException("Telefone não encontrado.");

        var vet = request.ToDomain();
        veterinariaRepository.Add(vet);
        return VeterinariaResponse.FromDomain(vet);
    }

    public bool Delete(Guid id) => veterinariaRepository.Delete(id);
}