using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de atendimento veterinário.
/// </summary>
public sealed class AtendimentoService(
    IAtendimentoRepository atendimentoRepository,
    IPetRepository petRepository,
    IRepository<Veterinaria> veterinariaRepository) : IAtendimentoService
{
    /// <inheritdoc />
    public IReadOnlyList<AtendimentoResponse> GetAll()
    {
        return atendimentoRepository.GetAll()
            .Select(AtendimentoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AtendimentoResponse? GetById(Guid id)
    {
        var atendimento = atendimentoRepository.GetById(id);
        return atendimento is null ? null : AtendimentoResponse.FromDomain(atendimento);
    }

    /// <inheritdoc />
    public IReadOnlyList<AtendimentoResponse> GetByPetId(Guid petId)
    {
        return atendimentoRepository.GetByPetId(petId)
            .Select(AtendimentoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<AtendimentoResponse> GetByVeterinariaId(Guid veterinariaId)
    {
        return atendimentoRepository.GetByVeterinariaId(veterinariaId)
            .Select(AtendimentoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AtendimentoResponse Create(AtendimentoRequest request)
    {
        if (!petRepository.ExistsById(request.PetId))
            throw new InvalidOperationException("Pet não encontrado.");

        if (!veterinariaRepository.ExistsById(request.VeterinariaId))
            throw new InvalidOperationException("Veterinária não encontrada.");

        var atendimento = request.ToDomain();
        atendimentoRepository.Add(atendimento);
        return AtendimentoResponse.FromDomain(atendimento);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return atendimentoRepository.Delete(id);
    }
}