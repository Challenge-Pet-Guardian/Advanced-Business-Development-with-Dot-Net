using PetGuardian.Domain.Common;
using PetGuardian.Domain.Enums;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Pet cadastrado no sistema. Pertence a uma <see cref="Familia"/> e pode ter
/// vários <see cref="Atendimento"/>s e <see cref="Tarefa"/>s associados.
/// </summary>
public sealed class Pet : BaseEntity
{
    public string   Nome     { get; private set; } = string.Empty;
    public string   Raca     { get; private set; } = string.Empty;
    public PortePet Porte    { get; private set; }
    public SexoPet  Sexo     { get; private set; }
    public int      Idade    { get; private set; }
    public bool     Castrado { get; private set; }

    // N:1
    public Guid     FamiliaId { get; private set; }
    public Familia? Familia   { get; private set; }

    // 1:N
    public List<Atendimento> Atendimentos { get; private set; } = [];
    public List<Tarefa>      Tarefas      { get; private set; } = [];

    // EF Core
    private Pet()
    {
    }

    public Pet(
        string   nome,
        string   raca,
        PortePet porte,
        SexoPet  sexo,
        int      idade,
        bool     castrado,
        Guid     familiaId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome do pet não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(raca))
            throw new DomainException("A raça do pet não pode ser vazia.");

        if (idade is < 0 or > 99)
            throw new DomainException("A idade do pet deve estar entre 0 e 99 anos.");

        if (familiaId == Guid.Empty)
            throw new DomainException("O pet deve estar associado a uma família válida.");

        Nome      = nome.Trim();
        Raca      = raca.Trim();
        Porte     = porte;
        Sexo      = sexo;
        Idade     = idade;
        Castrado  = castrado;
        FamiliaId = familiaId;
    }
    

    /// <summary>
    /// Registra a castração do pet.
    /// </summary>
    public void Castrar()
    {
        if (Castrado)
            throw new DomainException("O pet já foi castrado.");

        Castrado = true;
    }

    /// <summary>
    /// Atualiza a idade do pet (revisão anual).
    /// </summary>
    public void AtualizarIdade(int novaIdade)
    {
        if (novaIdade < Idade)
            throw new DomainException("A nova idade não pode ser menor que a atual.");

        if (novaIdade > 99)
            throw new DomainException("A idade do pet deve ser no máximo 99 anos.");

        Idade = novaIdade;
    }
}