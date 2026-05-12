using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>
/// Gerenciamento de atendimentos veterinários. Liga um pet a uma veterinária.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AtendimentoController(IAtendimentoService atendimentoService) : ControllerBase
{
    /// <summary>Lista todos os atendimentos.</summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AtendimentoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(atendimentoService.GetAll());

    /// <summary>Obtém um atendimento pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="200">Atendimento encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AtendimentoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var atendimento = atendimentoService.GetById(id);
        if (atendimento is null)
            return NotFound();

        return Ok(atendimento);
    }

    /// <summary>Lista atendimentos de um pet.</summary>
    /// <param name="petId">Id do pet.</param>
    /// <response code="200">Lista retornada (pode ser vazia).</response>
    [HttpGet("by-pet/{petId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<AtendimentoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByPet(Guid petId) =>
        Ok(atendimentoService.GetByPetId(petId));

    /// <summary>Lista atendimentos de uma veterinária.</summary>
    /// <param name="veterinariaId">Id da veterinária.</param>
    /// <response code="200">Lista retornada (pode ser vazia).</response>
    [HttpGet("by-veterinaria/{veterinariaId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<AtendimentoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByVeterinaria(Guid veterinariaId) =>
        Ok(atendimentoService.GetByVeterinariaId(veterinariaId));

    /// <summary>Registra um atendimento.</summary>
    /// <param name="request">Dados do atendimento (pet e veterinária devem existir).</param>
    /// <response code="201">Criado com sucesso.</response>
    /// <response code="400">Pet/veterinária inexistente ou dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(AtendimentoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] AtendimentoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = atendimentoService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Remove um atendimento pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido com sucesso.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) =>
        atendimentoService.Delete(id) ? NoContent() : NotFound();
}