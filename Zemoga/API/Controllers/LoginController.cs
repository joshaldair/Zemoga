using Application.Contracts.Identity;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private IConfiguration _config;
    private readonly IMediator _mediator;
    private readonly IAuthService _authService;

    public LoginController(IConfiguration config, IMediator mediator, IAuthService authService)
    {
        _config = config;
        _mediator = mediator;
        _authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
    {
        return Ok(await _authService.Login(request));
    }
}
