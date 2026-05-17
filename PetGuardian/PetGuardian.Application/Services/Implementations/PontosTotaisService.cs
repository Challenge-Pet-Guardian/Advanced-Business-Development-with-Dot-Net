using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.Services.Implementations;

public sealed class PontosTotaisService(
    IPontosTotaisRepository pontosTotaisRepository,
    IUsuarioRepository usuarioRepository) : IPontosTotaisService
{
    public IReadOnlyList<PontosTotaisResponse> GetAll() =>
        pontosTotaisRepository.GetAll().Select(PontosTotaisResponse.FromDomain).ToList();

    public PontosTotaisResponse? GetById(Guid id)
    {
        var p = pontosTotaisRepository.GetById(id);
        return p is null ? null : PontosTotaisResponse.FromDomain(p);
    }

    public PontosTotaisResponse? GetByUsuarioId(Guid usuarioId)
    {
        var p = pontosTotaisRepository.GetByUsuarioId(usuarioId);
        return p is null ? null : PontosTotaisResponse.FromDomain(p);
    }

    public PontosTotaisResponse Create(Guid usuarioId)
    {
        if (!usuarioRepository.ExistsById(usuarioId))
            throw new InvalidOperationException("Usuário não encontrado.");

        if (pontosTotaisRepository.ExistsForUsuario(usuarioId))
            throw new InvalidOperationException("Este usuário já possui registro de pontos.");

        var pontos = new PontosTotais(usuarioId);
        pontosTotaisRepository.Add(pontos);
        return PontosTotaisResponse.FromDomain(pontos);
    }

    public bool Delete(Guid id) => pontosTotaisRepository.Delete(id);
}