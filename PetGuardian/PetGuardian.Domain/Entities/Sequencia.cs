using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Sequência (streak) de atividades de uma <see cref="Familia"/> (1:1).
/// Registra quantos dias consecutivos a família cumpriu tarefas.
/// </summary>
public sealed class Sequencia : BaseEntity
{
    public int      SequenciaAtual  { get; private set; }
    public int      SequenciaMaxima { get; private set; }
    public DateTime DataUltimaAcao  { get; private set; }

    public Guid     FamiliaId { get; private set; }
    public Familia? Familia   { get; private set; }

    private Sequencia() { }

    public Sequencia(Guid familiaId)
    {
        if (familiaId == Guid.Empty)
            throw new DomainException("A sequência deve estar associada a uma família válida.");

        FamiliaId       = familiaId;
        SequenciaAtual  = 0;
        SequenciaMaxima = 0;
        DataUltimaAcao  = DateTime.UtcNow;
    }

    /// <summary>Incrementa a sequência e atualiza o recorde se necessário.</summary>
    public void Incrementar()
    {
        SequenciaAtual++;
        DataUltimaAcao = DateTime.UtcNow;

        if (SequenciaAtual > SequenciaMaxima)
            SequenciaMaxima = SequenciaAtual;
    }

    /// <summary>Reinicia a sequência atual (sem alterar o recorde).</summary>
    public void Reiniciar()
    {
        SequenciaAtual = 0;
        DataUltimaAcao = DateTime.UtcNow;
    }
}