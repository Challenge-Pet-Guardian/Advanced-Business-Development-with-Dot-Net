using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Família que agrega <see cref="Usuario"/>s. Possui uma <see cref="Sequencia"/> de streak (1:1).
/// </summary>
public sealed class Familia : BaseEntity
{
    public string NomeFamilia { get; private set; } = string.Empty;

    public List<Usuario> Usuarios { get; private set; } = [];
    public Sequencia?    Sequencia { get; private set; }

    private Familia() { }

    public Familia(string nomeFamilia)
    {
        if (string.IsNullOrWhiteSpace(nomeFamilia))
            throw new DomainException("O nome da família não pode ser vazio.");

        nomeFamilia = nomeFamilia.Trim();

        if (nomeFamilia.Length > 30)
            throw new DomainException("O nome da família deve ter no máximo 30 caracteres.");

        NomeFamilia = nomeFamilia;
    }
}