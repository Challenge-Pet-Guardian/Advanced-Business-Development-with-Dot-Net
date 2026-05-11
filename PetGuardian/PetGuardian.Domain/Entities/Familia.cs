using PetGuardian.Domain.Common;

namespace PetGuardian.Domain.Entities;

public class Familia : BaseEntity
{
    public string Nome { get; private set; }
}