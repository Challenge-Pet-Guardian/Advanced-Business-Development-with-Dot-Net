using Microsoft.VisualBasic;
using PetGuardian.Domain.Common;

namespace PetGuardian.Domain.Entities;

public class Atendimento : BaseEntity
{
    public string TipoAtendimento { get; private set; }
    public DateTime Data { get; private set; }
    public string Anotacoes { get; private set; }
    public string Status { get; private set; }
    public Decimal Valor { get; private set; }
}
