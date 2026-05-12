using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de endereço.
/// </summary>
public sealed class EnderecoService(IRepository<Endereco> enderecoRepository) : IEnderecoService
{
    /// <inheritdoc />
    public IReadOnlyList<EnderecoResponse> GetAll()
    {
        return enderecoRepository.GetAll()
            .Select(EnderecoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public EnderecoResponse? GetById(Guid id)
    {
        var endereco = enderecoRepository.GetById(id);
        return endereco is null ? null : EnderecoResponse.FromDomain(endereco);
    }

    /// <inheritdoc />
    public EnderecoResponse Create(EnderecoRequest request)
    {
        var endereco = request.ToDomain();
        enderecoRepository.Add(endereco);
        return EnderecoResponse.FromDomain(endereco);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return enderecoRepository.Delete(id);
    }
}