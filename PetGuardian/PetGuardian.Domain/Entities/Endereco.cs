using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Endereço físico. Relacionamento 1:1 com <see cref="Usuario"/> e com <see cref="Veterinaria"/>.
/// </summary>
public sealed class Endereco : BaseEntity
{
    public string Rua    { get; private set; } = string.Empty;
    public string Bairro { get; private set; } = string.Empty;
    public string Cidade { get; private set; } = string.Empty;
    public string Estado { get; private set; } = string.Empty;

    // EF Core
    private Endereco()
    {
    }

    public Endereco(string rua, string bairro, string cidade, string estado)
    {
        Rua    = Validar(rua,    nameof(Rua),    100);
        Bairro = Validar(bairro, nameof(Bairro), 50);
        Cidade = Validar(cidade, nameof(Cidade), 50);
        Estado = Validar(estado, nameof(Estado), 50);
    }

    // Regras

    private static string Validar(string valor, string campo, int max)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new DomainException($"{campo} não pode ser vazio.");

        valor = valor.Trim();

        if (valor.Length > max)
            throw new DomainException($"{campo} deve ter no máximo {max} caracteres.");

        return valor;
    }
}