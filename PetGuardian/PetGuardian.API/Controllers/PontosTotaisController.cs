using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>Saldo total de pontos por usuário (1:1).</summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class PontosTotaisController(IPontosTotaisService pontosTotaisService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PontosTotaisResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(pontosTotaisService.GetAll());

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PontosTotaisResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var p = pontosTotaisService.GetById(id);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpGet("by-usuario/{usuarioId:guid}")]
    [ProducesResponseType(typeof(PontosTotaisResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetByUsuario(Guid usuarioId)
    {
        var p = pontosTotaisService.GetByUsuarioId(usuarioId);
        return p is null ? NotFound() : Ok(p);
    }

    /// <summary>Inicializa o registro de pontos para um usuário.</summary>
    [HttpPost("{usuarioId:guid}")]
    [ProducesResponseType(typeof(PontosTotaisResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(Guid usuarioId)
    {
        var created = pontosTotaisService.Create(usuarioId);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) => pontosTotaisService.Delete(id) ? NoContent() : NotFound();
}