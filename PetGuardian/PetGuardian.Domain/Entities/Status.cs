using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Status de ciclo de vida compartilhado por <see cref="Tarefa"/> e <see cref="Atendimento"/>.
/// Valores esperados: CONCLUIDO | EXPIRADO | PENDENTE.
/// </summary>
public sealed class Status : BaseEntity
{
    private static readonly string[] ValoresValidos = ["CONCLUIDO", "EXPIRADO", "PENDENTE"];

    public string Nome { get; private set; } = string.Empty;

    public List<Tarefa>      Tarefas      { get; private set; } = [];
    public List<Atendimento> Atendimentos { get; private set; } = [];

    private Status() { }

    public Status(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O status não pode ser vazio.");

        nome = nome.Trim().ToUpperInvariant();

        if (!ValoresValidos.Contains(nome))
            throw new DomainException($"Status inválido. Valores aceitos: {string.Join(", ", ValoresValidos)}.");

        Nome = nome;
    }
}