using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Tarefa de cuidado vinculada a um <see cref="Pet"/> e a um <see cref="Usuario"/> responsável.
/// Ao ser concluída gera um <see cref="HistoricoPontos"/>.
/// </summary>
public sealed class Tarefa : BaseEntity
{
    public string   Titulo       { get; private set; } = string.Empty;
    public int      PontosTarefa { get; private set; }
    public string   Descricao    { get; private set; } = string.Empty;
    public DateTime Criacao      { get; private set; }
    public DateTime Prazo        { get; private set; }

    public Guid     PetId     { get; private set; }
    public Pet?     Pet       { get; private set; }

    public Guid     UsuarioId { get; private set; }
    public Usuario? Usuario   { get; private set; }

    public Guid    StatusId { get; private set; }
    public Status? Status   { get; private set; }

    public List<HistoricoPontos> HistoricoPontos { get; private set; } = [];

    private Tarefa() { }

    public Tarefa(
        string   titulo,
        int      pontosTarefa,
        string   descricao,
        DateTime prazo,
        Guid     petId,
        Guid     usuarioId,
        Guid     statusId)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new DomainException("O título não pode ser vazio.");

        titulo = titulo.Trim();

        if (titulo.Length > 30)
            throw new DomainException("O título deve ter no máximo 30 caracteres.");

        if (pontosTarefa < 0)
            throw new DomainException("Os pontos da tarefa não podem ser negativos.");

        if (string.IsNullOrWhiteSpace(descricao))
            throw new DomainException("A descrição não pode ser vazia.");

        descricao = descricao.Trim();

        if (descricao.Length > 200)
            throw new DomainException("A descrição deve ter no máximo 200 caracteres.");

        if (prazo <= DateTime.UtcNow)
            throw new DomainException("O prazo deve ser uma data/hora futura.");

        if (petId == Guid.Empty)
            throw new DomainException("A tarefa deve estar associada a um pet válido.");

        if (usuarioId == Guid.Empty)
            throw new DomainException("A tarefa deve ter um usuário responsável válido.");

        if (statusId == Guid.Empty)
            throw new DomainException("O status da tarefa é obrigatório.");

        Titulo       = titulo;
        PontosTarefa = pontosTarefa;
        Descricao    = descricao;
        Criacao      = DateTime.UtcNow;
        Prazo        = prazo;
        PetId        = petId;
        UsuarioId    = usuarioId;
        StatusId     = statusId;
    }

    public void EstenderPrazo(DateTime novoPrazo)
    {
        if (novoPrazo <= DateTime.UtcNow)
            throw new DomainException("O novo prazo deve ser futuro.");
        if (novoPrazo <= Prazo)
            throw new DomainException("O novo prazo deve ser posterior ao prazo atual.");
        Prazo = novoPrazo;
    }
}