using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>
/// Gerenciamento de famílias. Agrupa usuários e pets.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class FamiliaController(IFamiliaService familiaService) : ControllerBase
{
    /// <summary>Lista todas as famílias.</summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FamiliaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(familiaService.GetAll());

    /// <summary>Obtém uma família pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="200">Família encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FamiliaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var familia = familiaService.GetById(id);
        if (familia is null)
            return NotFound();

        return Ok(familia);
    }

    /// <summary>Cria uma família.</summary>
    /// <param name="request">Nome da família.</param>
    /// <response code="201">Criada com sucesso.</response>
    /// <response code="400">Nome duplicado ou dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(FamiliaResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] FamiliaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = familiaService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Remove uma família pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida com sucesso.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) =>
        familiaService.Delete(id) ? NoContent() : NotFound();
}