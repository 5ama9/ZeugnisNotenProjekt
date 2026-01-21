using System.Net.Http.Json;
using Shared.Models.DTOs;

namespace Web.Services;

public class GradeService : IGradeService
{
    private readonly HttpClient _httpClient;

    public GradeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GradeDto>> GetAsync()
    {
        //wait for the api
        List<GradeDto>? grades = await _httpClient.GetFromJsonAsync<List<GradeDto>>("api/grade");
        return grades ?? new List<GradeDto>();
    }

    public async Task AddAsync(GradeDto newGrade)
    {
        //wait for api
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/grade", newGrade);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<RoundingDto>> GetRoundingsAsync()
    {
        var roundings = await _httpClient
            .GetFromJsonAsync<List<RoundingDto>>("api/rounding");

        return roundings ?? new List<RoundingDto>();
    }

}
