using System.Net.Http.Json;
using Shared.Models.DTOs;
using Shared.Models;

namespace Web.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequestDto loginModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginModel);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }
        return null;
    }
}
