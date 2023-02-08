using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Features.Comments.Queries.DTO;
using Application.Features.Comments.Queries;
using Application.Features.Comments.Commands;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : Controller
{
    private readonly IMediator _mediator;
    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CommentDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CommentDTO>>> GetPost()
    {
        var query = new GetCommentQuery();
        var articulos = await _mediator.Send(query);
        return Ok(articulos);

    }


    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateComment([FromBody] CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteComment(int id)
    {
        var command = new DeleteCommentCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
