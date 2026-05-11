using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Clínica / hospital veterinário. Possui um <see cref="Endereco"/> exclusivo (1:1)
/// e é responsável por vários <see cref="Atendimento"/>s.
/// </summary>
public sealed class Veterinaria : BaseEntity
{
    public string Nome { get; private set; } = string.Empty;

    // 1:1 
    public Guid      EnderecoId { get; private set; }
    public Endereco? Endereco   { get; private set; }

    // 1:N
    public List<Atendimento> Atendimentos { get; private set; } = [];

    // EF Core
    private Veterinaria()
    {
    }

    public Veterinaria(string nome, Guid enderecoId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome da veterinária não pode ser vazio.");

        nome = nome.Trim();

        if (nome.Length > 30)
            throw new DomainException("O nome da veterinária deve ter no máximo 30 caracteres.");

        if (enderecoId == Guid.Empty)
            throw new DomainException("A veterinária deve ter um endereço válido associado.");

        Nome       = nome;
        EnderecoId = enderecoId;
    }
}