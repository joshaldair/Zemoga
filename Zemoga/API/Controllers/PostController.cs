using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Features.Posts.Commands;
using Application.Features.Posts.Queries;
using Application.Features.Posts.Queries.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPost()
        {
            var query = new GetPostQuery();
            var articulos = await _mediator.Send(query);
            return Ok(articulos);

        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreatePost([FromBody] CreatePostCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Authorize(Roles = "Editor,Writer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePost([FromBody] UpdatePostCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("Approve")]
        [Authorize(Roles = "Editor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AprrovePost([FromBody] ApprovePostCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePost(int id)
        {
            var command = new DeletePostCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
