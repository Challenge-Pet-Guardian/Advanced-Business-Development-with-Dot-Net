using System.ComponentModel.DataAnnotations;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Application.DTOs;

/// <summary>Valores aceitos: CONCLUIDO | EXPIRADO | PENDENTE</summary>
public record StatusRequest(
    [property: Required][property: StringLength(15, MinimumLength = 2)] string Nome)
{
    public Status ToDomain() => new(Nome);
}