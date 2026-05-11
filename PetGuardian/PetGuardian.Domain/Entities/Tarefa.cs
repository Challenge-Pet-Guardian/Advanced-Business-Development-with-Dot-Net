using PetGuardian.Domain.Common;

namespace PetGuardian.Domain.Entities;

public class Tarefa : BaseEntity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateTime Criacao { get; private set; }
    public DateTime Prazo { get; private set; }
    public string Status { get; private set; }
}