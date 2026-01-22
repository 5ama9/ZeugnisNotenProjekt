using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using Web.Services;

namespace Web.Pages;

public partial class Teacher
{
    private List<GradeDto> grades = new();
    private List<RoundingDto> roundings = new();
    private GradeDto newGrade = new();

    private string? _errorMessage;
    private string? _successMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            grades = await GradeService.GetAsync();
            roundings = await GradeService.GetRoundingsAsync();
        }
        catch
        {
            _errorMessage = "Error while loading data.";
        }
    }

    private async Task AddGrade()
    {
        try
        {
            await GradeService.AddAsync(newGrade);
            grades = await GradeService.GetAsync();
            newGrade = new GradeDto();
            _successMessage = "Success while adding Grade.";
        }
        catch
        {
            _errorMessage = "Error while adding grade.";
        }
    }
}
