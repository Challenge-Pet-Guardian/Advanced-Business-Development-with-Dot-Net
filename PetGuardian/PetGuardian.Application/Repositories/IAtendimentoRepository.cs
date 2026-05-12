using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Repositories;

/// <summary>
/// Contrato de persistência para <see cref="Atendimento"/>.
/// </summary>
public interface IAtendimentoRepository : IRepository<Atendimento>
{
    /// <summary>Lista atendimentos de um pet específico.</summary>
    IReadOnlyList<Atendimento> GetByPetId(Guid petId);

    /// <summary>Lista atendimentos realizados por uma veterinária específica.</summary>
    IReadOnlyList<Atendimento> GetByVeterinariaId(Guid veterinariaId);
}