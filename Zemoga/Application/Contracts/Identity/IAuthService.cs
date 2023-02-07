using Application.Models;

namespace Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest authRequest);
}
