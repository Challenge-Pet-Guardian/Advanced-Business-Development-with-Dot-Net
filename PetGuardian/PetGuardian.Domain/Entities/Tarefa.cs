using PetGuardian.Domain.Common;
using PetGuardian.Domain.Enums;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Tarefa de cuidado associada a um <see cref="Pet"/>, atribuída a um <see cref="Usuario"/>
/// e vinculada à <see cref="Familia"/> dona do pet.
/// </summary>
public sealed class Tarefa : BaseEntity
{
    public string      Titulo    { get; private set; } = string.Empty;
    public string      Descricao { get; private set; } = string.Empty;
    public DateTime    Criacao   { get; private set; }
    public DateTime    Prazo     { get; private set; }
    public StatusTarefa Status   { get; private set; }

    // N:1
    public Guid      UsuarioId { get; private set; }
    public Usuario?  Usuario   { get; private set; }

    public Guid  PetId { get; private set; }
    public Pet?  Pet   { get; private set; }

    public Guid     FamiliaId { get; private set; }
    public Familia? Familia   { get; private set; }

    // EF Core
    private Tarefa()
    {
    }

    public Tarefa(
        string titulo,
        string descricao,
        DateTime prazo,
        Guid usuarioId,
        Guid petId,
        Guid familiaId)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new DomainException("O título da tarefa não pode ser vazio.");

        titulo = titulo.Trim();

        if (titulo.Length > 30)
            throw new DomainException("O título deve ter no máximo 30 caracteres.");

        if (string.IsNullOrWhiteSpace(descricao))
            throw new DomainException("A descrição da tarefa não pode ser vazia.");

        descricao = descricao.Trim();

        if (descricao.Length > 200)
            throw new DomainException("A descrição deve ter no máximo 200 caracteres.");

        if (prazo <= DateTime.UtcNow)
            throw new DomainException("O prazo deve ser uma data/hora futura.");

        if (usuarioId == Guid.Empty)
            throw new DomainException("A tarefa deve ter um usuário responsável válido.");

        if (petId == Guid.Empty)
            throw new DomainException("A tarefa deve estar associada a um pet válido.");

        if (familiaId == Guid.Empty)
            throw new DomainException("A tarefa deve estar associada a uma família válida.");

        Titulo = titulo;
        Descricao = descricao;
        Criacao = DateTime.UtcNow;
        Prazo = prazo;
        Status = StatusTarefa.Pendente;
        UsuarioId = usuarioId;
        PetId = petId;
        FamiliaId = familiaId;
    }

    /// <summary>
    /// Avança o status da tarefa. Não reabre tarefas já canceladas.
    /// </summary>
    public void AtualizarStatus(StatusTarefa novoStatus)
    {
        if (Status == StatusTarefa.Cancelada)
            throw new DomainException("Não é possível alterar o status de uma tarefa cancelada.");

        Status = novoStatus;
    }

    /// <summary>
    /// Estende o prazo da tarefa para uma data futura.
    /// </summary>
    public void EstenderPrazo(DateTime novoPrazo)
    {
        if (novoPrazo <= DateTime.UtcNow)
            throw new DomainException("O novo prazo deve ser uma data/hora futura.");

        if (novoPrazo <= Prazo)
            throw new DomainException("O novo prazo deve ser posterior ao prazo atual.");

        Prazo = novoPrazo;
    }
}