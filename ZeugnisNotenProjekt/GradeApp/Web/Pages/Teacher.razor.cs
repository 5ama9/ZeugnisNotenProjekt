using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using Web.Services;

namespace Web.Pages;

public partial class Teacher
{
    // List to display the grades and roundings
    private List<GradeDto> grades = new();
    private List<RoundingDto> roundings = new();
    private GradeDto newGrade = new();

    // error and success messages for user information
    private string? _errorMessage;
    private string? _successMessage;

    // Task to load the grades and roundings
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

    /// <summary>
    /// Method to add the grades
    /// </summary>
    /// <returns>The success message</returns>
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
