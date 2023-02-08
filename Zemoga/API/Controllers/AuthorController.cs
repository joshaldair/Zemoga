using Application.Features.Authors.Commands;
using Application.Features.Authors.Queries;
using Application.Features.Authors.Queries.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorController : Controller
{
    private readonly IMediator _mediator;
	public AuthorController(IMediator mediator)
	{
		_mediator = mediator;
	}

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AuthorDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> ObtenerArticulos()
    {
        var query = new GetAuthorQuery();
        var articulos = await _mediator.Send(query);
        return Ok(articulos);

    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CrearArticulo([FromBody] CreateAuthorCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> ActualizarArticulo([FromBody] UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> BorrarArticulo(int id)
    {
        var command = new DeleteAuthorCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
