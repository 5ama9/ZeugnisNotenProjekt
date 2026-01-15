using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Web.Services;
using Shared.Models.DTOs;

namespace Web.Pages;

public partial class Login
{
    [Inject] private IAuthService _authService { get; set; }
    [Inject] private IJSRuntime JSRuntime { get; set; }

    private LoginRequestDto loginModel = new();

    private string _errorMessage;
    private string _successMessage;

    private async Task HandleLogin()
    {
        var response = await _authService.LoginAsync(loginModel);
        if (response != null)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "jwtToken", response.Token);
            _successMessage = "Login successful.";
        }
        else
        {
            _errorMessage = "Login failed. Please check credentials.";
        }
    }
}