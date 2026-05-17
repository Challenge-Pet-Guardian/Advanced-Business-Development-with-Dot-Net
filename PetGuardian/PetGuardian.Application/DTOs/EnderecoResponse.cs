using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

public record EnderecoResponse(Guid Id, string Cep, string Rua, Guid BairroId)
{
    public static EnderecoResponse FromDomain(Endereco e) => new(e.Id, e.Cep, e.Rua, e.BairroId);
}