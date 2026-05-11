using PetGuardian.Domain.Common;

namespace PetGuardian.Domain.Entities;

public class Pet : BaseEntity
{
    public string Nome { get; private set; }
    public string Raca { get; private set; }
    public string Porte { get; private set; }
    public string Sexo { get; private set; }
    public int Idade { get; private set; }
    public bool Castrado { get; private set; }
    
}