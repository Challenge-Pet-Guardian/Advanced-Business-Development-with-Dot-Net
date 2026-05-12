using Microsoft.AspNetCore.Mvc;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.API.Controllers;

/// <summary>
/// Gerenciamento de usuários. Senha nunca é exposta nas respostas.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
{
    /// <summary>Lista todos os usuários.</summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<UsuarioResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(usuarioService.GetAll());

    /// <summary>Obtém um usuário pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="200">Usuário encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var usuario = usuarioService.GetById(id);
        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    /// <summary>Obtém um usuário pelo e-mail.</summary>
    /// <param name="email">Endereço de e-mail.</param>
    /// <response code="200">Usuário encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("by-email")]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetByEmail([FromQuery] string email)
    {
        var usuario = usuarioService.GetByEmail(email);
        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    /// <summary>Cadastra um usuário.</summary>
    /// <param name="request">Dados de cadastro (família e endereço devem existir previamente).</param>
    /// <response code="201">Criado com sucesso.</response>
    /// <response code="400">E-mail duplicado, família/endereço inexistente ou dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] UsuarioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = usuarioService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Remove um usuário pelo Id.</summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido com sucesso.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) =>
        usuarioService.Delete(id) ? NoContent() : NotFound();
}