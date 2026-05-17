using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>Histórico de pontos ganhos por conclusão de tarefas.</summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class HistoricoPontosController(IHistoricoPontosService historicoService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<HistoricoPontosResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(historicoService.GetAll());

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(HistoricoPontosResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var h = historicoService.GetById(id);
        return h is null ? NotFound() : Ok(h);
    }

    [HttpGet("by-usuario/{usuarioId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<HistoricoPontosResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByUsuario(Guid usuarioId) => Ok(historicoService.GetByUsuarioId(usuarioId));

    [HttpGet("by-tarefa/{tarefaId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<HistoricoPontosResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByTarefa(Guid tarefaId) => Ok(historicoService.GetByTarefaId(tarefaId));

    [HttpPost]
    [ProducesResponseType(typeof(HistoricoPontosResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] HistoricoPontosRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = historicoService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) => historicoService.Delete(id) ? NoContent() : NotFound();
}