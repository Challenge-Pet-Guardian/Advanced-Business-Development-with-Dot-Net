using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>
/// Gerenciamento de veterinárias. O endereço deve ser criado previamente.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class VeterinariaController(IVeterinariaService veterinariaService) : ControllerBase
{
    /// <summary>Lista todas as veterinárias.</summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<VeterinariaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(veterinariaService.GetAll());

    /// <summary>Obtém uma veterinária pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="200">Veterinária encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(VeterinariaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var veterinaria = veterinariaService.GetById(id);
        if (veterinaria is null)
            return NotFound();

        return Ok(veterinaria);
    }

    /// <summary>Cadastra uma veterinária.</summary>
    /// <param name="request">Nome e endereço (deve existir previamente).</param>
    /// <response code="201">Criada com sucesso.</response>
    /// <response code="400">Nome duplicado, endereço inexistente ou dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(VeterinariaResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] VeterinariaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = veterinariaService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Remove uma veterinária pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida com sucesso.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) =>
        veterinariaService.Delete(id) ? NoContent() : NotFound();
}