using Shared.Models.DTOs;

namespace Web.Pages;

public partial class Prorector
{
    private List<GradeDto> grades = new();
    private List<RoundingDto> roundings = new();

    private GradeDto newGrade = new();
    private string? _errorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            grades = await GradeService.GetAsync();
            roundings = await GradeService.GetRoundingsAsync();
        }
        catch
        {
            _errorMessage = "Error while getting data.";
        }
    }

    private async Task AddGrade()
    {
        try
        {
            await GradeService.AddAsync(newGrade);
            grades = await GradeService.GetAsync();
            newGrade = new GradeDto();
        }
        catch
        {
            _errorMessage = "Error while adding grade.";
        }
    }
}
