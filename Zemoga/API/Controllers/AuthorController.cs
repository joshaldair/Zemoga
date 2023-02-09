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
    [Authorize(Roles = "Admin,Editor,Writer,Public")]
    [ProducesResponseType(typeof(IEnumerable<AuthorDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthor()
    {

        var query = new GetAuthorQuery();
        var articulos = await _mediator.Send(query);
        return Ok(articulos);

    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateAiuthor([FromBody] CreateAuthorCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteAuthor(int id)
    {
        var command = new DeleteAuthorCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
