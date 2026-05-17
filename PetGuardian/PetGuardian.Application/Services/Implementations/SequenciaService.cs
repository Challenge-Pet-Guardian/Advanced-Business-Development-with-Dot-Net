using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class SequenciaService(
    ISequenciaRepository sequenciaRepository,
    IRepository<Familia> familiaRepository) : ISequenciaService
{
    public IReadOnlyList<SequenciaResponse> GetAll() =>
        sequenciaRepository.GetAll().Select(SequenciaResponse.FromDomain).ToList();

    public SequenciaResponse? GetById(Guid id)
    {
        var s = sequenciaRepository.GetById(id);
        return s is null ? null : SequenciaResponse.FromDomain(s);
    }

    public SequenciaResponse? GetByFamiliaId(Guid familiaId)
    {
        var s = sequenciaRepository.GetByFamiliaId(familiaId);
        return s is null ? null : SequenciaResponse.FromDomain(s);
    }

    public SequenciaResponse Create(Guid familiaId)
    {
        if (!familiaRepository.ExistsById(familiaId))
            throw new InvalidOperationException("Família não encontrada.");

        if (sequenciaRepository.ExistsForFamilia(familiaId))
            throw new InvalidOperationException("Esta família já possui uma sequência registrada.");

        var sequencia = new Sequencia(familiaId);
        sequenciaRepository.Add(sequencia);
        return SequenciaResponse.FromDomain(sequencia);
    }

    public bool Delete(Guid id) => sequenciaRepository.Delete(id);
}