using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Features.Comments.Queries.DTO;
using Application.Features.Comments.Queries;
using Application.Features.Comments.Commands;

namespace API.Controllers
{
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
        public async Task<ActionResult<int>> CreateAiuthor([FromBody] CreateCommentCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
