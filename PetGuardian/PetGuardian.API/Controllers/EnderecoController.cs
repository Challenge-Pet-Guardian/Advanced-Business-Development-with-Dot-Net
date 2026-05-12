using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>
/// Gerenciamento de endereços. Deve ser criado antes de Usuario ou Veterinaria.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class EnderecoController(IEnderecoService enderecoService) : ControllerBase
{
    /// <summary>Lista todos os endereços.</summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<EnderecoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(enderecoService.GetAll());

    /// <summary>Obtém um endereço pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="200">Endereço encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var endereco = enderecoService.GetById(id);
        if (endereco is null)
            return NotFound();

        return Ok(endereco);
    }

    /// <summary>Cria um endereço.</summary>
    /// <param name="request">Dados do endereço.</param>
    /// <response code="201">Criado com sucesso.</response>
    /// <response code="400">Dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] EnderecoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = enderecoService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Remove um endereço pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido com sucesso.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) =>
        enderecoService.Delete(id) ? NoContent() : NotFound();
}