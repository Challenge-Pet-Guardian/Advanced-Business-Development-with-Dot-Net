using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Saldo total de pontos de um <see cref="Usuario"/> (1:1).
/// Atualizado a cada conclusão de tarefa via <see cref="HistoricoPontos"/>.
/// </summary>
public sealed class PontosTotais : BaseEntity
{
    public int QtdPontos { get; private set; }

    public Guid     UsuarioId { get; private set; }
    public Usuario? Usuario   { get; private set; }

    private PontosTotais() { }

    public PontosTotais(Guid usuarioId)
    {
        if (usuarioId == Guid.Empty)
            throw new DomainException("Os pontos devem estar associados a um usuário válido.");

        UsuarioId  = usuarioId;
        QtdPontos  = 0;
    }

    /// <summary>Adiciona pontos ao saldo do usuário.</summary>
    public void Adicionar(int pontos)
    {
        if (pontos <= 0)
            throw new DomainException("A quantidade de pontos a adicionar deve ser positiva.");

        QtdPontos += pontos;
    }
}