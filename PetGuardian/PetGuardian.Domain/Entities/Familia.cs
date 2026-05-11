using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Família que agrega <see cref="Usuario"/>s e <see cref="Pet"/>s.
/// Um pet pertence a uma família; um usuário também pertence a uma família.
/// </summary>
public sealed class Familia : BaseEntity
{
    public string Nome { get; private set; } = string.Empty;

    // 1:N
    public List<Usuario> Usuarios { get; private set; } = [];
    public List<Pet>     Pets     { get; private set; } = [];

    // EF Core
    private Familia()
    {
    }

    public Familia(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome da família não pode ser vazio.");

        nome = nome.Trim();

        if (nome.Length > 30)
            throw new DomainException("O nome da família deve ter no máximo 30 caracteres.");

        Nome = nome;
    }
}