using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>
/// Gerenciamento de pets. Um pet pertence a uma família.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class PetController(IPetService petService) : ControllerBase
{
    /// <summary>Lista todos os pets.</summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PetResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(petService.GetAll());

    /// <summary>Obtém um pet pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="200">Pet encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var pet = petService.GetById(id);
        if (pet is null)
            return NotFound();

        return Ok(pet);
    }

    /// <summary>Lista todos os pets de uma família.</summary>
    /// <param name="familiaId">Id da família.</param>
    /// <response code="200">Lista retornada (pode ser vazia).</response>
    [HttpGet("by-familia/{familiaId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<PetResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByFamilia(Guid familiaId) =>
        Ok(petService.GetByFamiliaId(familiaId));

    /// <summary>Cadastra um pet.</summary>
    /// <param name="request">Dados do pet.</param>
    /// <response code="201">Criado com sucesso.</response>
    /// <response code="400">Família inexistente ou dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(PetResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] PetRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = petService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Remove um pet pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido com sucesso.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) =>
        petService.Delete(id) ? NoContent() : NotFound();
}