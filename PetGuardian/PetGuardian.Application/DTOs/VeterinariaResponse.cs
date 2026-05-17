using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record VeterinariaResponse(Guid Id, string Nome, Guid EnderecoId, Guid TelefoneId)
{
    public static VeterinariaResponse FromDomain(Veterinaria v) => new(v.Id, v.Nome, v.EnderecoId, v.TelefoneId);
}