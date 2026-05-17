using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Endereço físico. Hierarquia: Endereco → <see cref="Bairro"/> → <see cref="Cidade"/> → <see cref="Estado"/>.
/// Relacionamento 1:1 com <see cref="Usuario"/> e com <see cref="Veterinaria"/>.
/// </summary>
public sealed class Endereco : BaseEntity
{
    public string Cep { get; private set; } = string.Empty;
    public string Rua { get; private set; } = string.Empty;

    public Guid    BairroId { get; private set; }
    public Bairro? Bairro   { get; private set; }

    private Endereco() { }

    public Endereco(string cep, string rua, Guid bairroId)
    {
        if (string.IsNullOrWhiteSpace(cep))
            throw new DomainException("O CEP não pode ser vazio.");

        cep = cep.Trim().Replace("-", "");

        if (cep.Length != 8)
            throw new DomainException("O CEP deve ter 8 dígitos.");

        if (string.IsNullOrWhiteSpace(rua))
            throw new DomainException("A rua não pode ser vazia.");

        if (bairroId == Guid.Empty)
            throw new DomainException("O endereço deve estar associado a um bairro válido.");

        Cep      = cep;
        Rua      = rua.Trim();
        BairroId = bairroId;
    }
}