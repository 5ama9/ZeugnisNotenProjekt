using Microsoft.JSInterop;

namespace Web.Services;

/// <summary>
/// CustomHttp handler to get the JWT
/// </summary>
public class CustomHttpHandler : DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;

    public CustomHttpHandler(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Method to save the token in the local storage
    /// </summary>
    /// <param name="request">A http message sent to the handler</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Reads the token</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "jwtToken");

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
