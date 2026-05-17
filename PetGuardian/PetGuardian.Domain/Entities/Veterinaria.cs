using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Clínica/hospital veterinário. Possui endereço e telefone exclusivos (1:1).
/// </summary>
public sealed class Veterinaria : BaseEntity
{
    public string Nome { get; private set; } = string.Empty;

    public Guid      EnderecoId { get; private set; }
    public Endereco? Endereco   { get; private set; }

    public Guid      TelefoneId { get; private set; }
    public Telefone? Telefone   { get; private set; }

    public List<Atendimento> Atendimentos { get; private set; } = [];

    private Veterinaria() { }

    public Veterinaria(string nome, Guid enderecoId, Guid telefoneId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome da veterinária não pode ser vazio.");

        nome = nome.Trim();

        if (nome.Length > 30)
            throw new DomainException("O nome da veterinária deve ter no máximo 30 caracteres.");

        if (enderecoId == Guid.Empty)
            throw new DomainException("A veterinária deve ter um endereço válido.");

        if (telefoneId == Guid.Empty)
            throw new DomainException("A veterinária deve ter um telefone válido.");

        Nome       = nome;
        EnderecoId = enderecoId;
        TelefoneId = telefoneId;
    }
}