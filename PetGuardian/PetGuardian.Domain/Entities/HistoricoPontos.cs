using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Registro de pontos ganhos ao concluir uma <see cref="Tarefa"/>.
/// Permite rastrear o histórico de recompensas por usuário.
/// </summary>
public sealed class HistoricoPontos : BaseEntity
{
    public int      PontosGanhos  { get; private set; }
    public DateTime DataConclusao { get; private set; }

    public Guid     TarefaId  { get; private set; }
    public Tarefa?  Tarefa    { get; private set; }

    public Guid     UsuarioId { get; private set; }
    public Usuario? Usuario   { get; private set; }

    private HistoricoPontos() { }

    public HistoricoPontos(int pontosGanhos, Guid tarefaId, Guid usuarioId)
    {
        if (pontosGanhos < 0)
            throw new DomainException("Os pontos ganhos não podem ser negativos.");

        if (tarefaId == Guid.Empty)
            throw new DomainException("O histórico deve estar associado a uma tarefa válida.");

        if (usuarioId == Guid.Empty)
            throw new DomainException("O histórico deve estar associado a um usuário válido.");

        PontosGanhos  = pontosGanhos;
        DataConclusao = DateTime.UtcNow;
        TarefaId      = tarefaId;
        UsuarioId     = usuarioId;
    }
}