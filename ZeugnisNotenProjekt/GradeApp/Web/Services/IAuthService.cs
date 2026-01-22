using Shared.Models.DTOs;
using Shared.Models;

namespace Web.Services;


public interface IAuthService
{
    /// <summary>
    /// Method to Login (generate and validate token)
    /// </summary>
    /// <param name="loginModel">Using the DTO as Model</param>
    /// <returns>Logs the user in</returns>
    Task<AuthResponse?> LoginAsync(LoginRequestDto loginModel);
}
