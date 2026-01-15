using Shared.Models.DTOs;
using Shared.Models;

namespace Web.Services;


public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(LoginRequestDto loginModel);
}
