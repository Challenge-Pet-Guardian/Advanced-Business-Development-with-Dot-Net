using PetGuardian.Domain.Common;
using PetGuardian.Domain.Enums;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Registro de um atendimento veterinário. Liga um <see cref="Pet"/> a uma
/// <see cref="Veterinaria"/> numa data específica.
/// </summary>
public sealed class Atendimento : BaseEntity
{
    public TipoAtendimento   TipoAtendimento { get; private set; }
    public DateTime          Data            { get; private set; }
    public string            Anotacoes       { get; private set; } = string.Empty;
    public StatusAtendimento Status          { get; private set; }
    public decimal           Valor           { get; private set; }

    // N:1
    public Guid         VeterinariaId { get; private set; }
    public Veterinaria? Veterinaria   { get; private set; }

    public Guid PetId { get; private set; }
    public Pet? Pet   { get; private set; }

    // EF Core
    private Atendimento()
    {
    }

    public Atendimento(
        TipoAtendimento tipo,
        DateTime        data,
        string          anotacoes,
        decimal         valor,
        Guid            veterinariaId,
        Guid            petId)
    {
        if (string.IsNullOrWhiteSpace(anotacoes))
            throw new DomainException("As anotações não podem ser vazias.");

        anotacoes = anotacoes.Trim();

        if (anotacoes.Length > 300)
            throw new DomainException("As anotações devem ter no máximo 300 caracteres.");

        if (valor < 0)
            throw new DomainException("O valor do atendimento não pode ser negativo.");

        if (veterinariaId == Guid.Empty)
            throw new DomainException("O atendimento deve estar associado a uma veterinária válida.");

        if (petId == Guid.Empty)
            throw new DomainException("O atendimento deve estar associado a um pet válido.");

        TipoAtendimento = tipo;
        Data            = data;
        Anotacoes       = anotacoes;
        Status          = StatusAtendimento.Agendado;
        Valor           = valor;
        VeterinariaId   = veterinariaId;
        PetId           = petId;
    }
    
    /// <summary>
    /// Avança ou reverte o status do atendimento.
    /// Não permite reabrir um atendimento já cancelado.
    /// </summary>
    public void AtualizarStatus(StatusAtendimento novoStatus)
    {
        if (Status == StatusAtendimento.Cancelado)
            throw new DomainException("Não é possível alterar o status de um atendimento cancelado.");

        Status = novoStatus;
    }

    /// <summary>
    /// Corrige o valor cobrado (ex.: ajuste pós-consulta).
    /// </summary>
    public void AtualizarValor(decimal novoValor)
    {
        if (novoValor < 0)
            throw new DomainException("O valor não pode ser negativo.");

        Valor = novoValor;
    }
}