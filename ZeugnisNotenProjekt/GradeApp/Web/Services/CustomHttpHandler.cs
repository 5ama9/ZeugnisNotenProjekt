using Microsoft.JSInterop;

namespace Web.Services;

public class CustomHttpHandler : DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;

    public CustomHttpHandler(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

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
