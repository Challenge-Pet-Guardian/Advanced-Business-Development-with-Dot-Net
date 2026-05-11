using PetGuardian.Domain.Common;

namespace PetGuardian.Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Telefone { get; private set; }
    public Endereco? Endereco { get; private set; }
}