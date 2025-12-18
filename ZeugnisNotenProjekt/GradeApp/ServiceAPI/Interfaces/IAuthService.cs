using Shared.Models.DTOs;

namespace ServiceAPI.Interfaces;

public interface IAuthService
{
    public LoginResponseDto? Login(LoginRequestDto loginRequest);
}
