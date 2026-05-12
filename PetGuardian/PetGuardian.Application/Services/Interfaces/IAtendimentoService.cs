using PetGuardian.Application.DTOs;

namespace PetGuardian.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de atendimento veterinário.
/// </summary>
public interface IAtendimentoService
{
    IReadOnlyList<AtendimentoResponse> GetAll();

    AtendimentoResponse? GetById(Guid id);

    IReadOnlyList<AtendimentoResponse> GetByPetId(Guid petId);

    IReadOnlyList<AtendimentoResponse> GetByVeterinariaId(Guid veterinariaId);

    AtendimentoResponse Create(AtendimentoRequest request);

    bool Delete(Guid id);
}