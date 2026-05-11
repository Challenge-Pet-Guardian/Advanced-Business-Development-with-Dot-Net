using PetGuardian.Domain.Common;

namespace PetGuardian.Domain.Entities;

public class Endereco : BaseEntity
{
    public string Rua { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
}