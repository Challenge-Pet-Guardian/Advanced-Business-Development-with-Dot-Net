using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>Sequência (streak) de atividades por família (1:1).</summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class SequenciaController(ISequenciaService sequenciaService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SequenciaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(sequenciaService.GetAll());

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SequenciaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var s = sequenciaService.GetById(id);
        return s is null ? NotFound() : Ok(s);
    }

    [HttpGet("by-familia/{familiaId:guid}")]
    [ProducesResponseType(typeof(SequenciaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetByFamilia(Guid familiaId)
    {
        var s = sequenciaService.GetByFamiliaId(familiaId);
        return s is null ? NotFound() : Ok(s);
    }

    /// <summary>Inicializa a sequência de uma família.</summary>
    [HttpPost("{familiaId:guid}")]
    [ProducesResponseType(typeof(SequenciaResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(Guid familiaId)
    {
        var created = sequenciaService.Create(familiaId);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) => sequenciaService.Delete(id) ? NoContent() : NotFound();
}