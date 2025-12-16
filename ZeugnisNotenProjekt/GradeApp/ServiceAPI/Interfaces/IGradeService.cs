using Shared.Models;
using Shared.Models.DTOs;

namespace ServiceAPI.Interfaces;

public interface IGradeService
{
    /// <summary>
    /// Adds the new grade.
    /// </summary>
    /// <param name="createdGrade">The created grade DTO.</param>
    /// <param name="userId">The user identifier from JWT.</param>
    /// <returns>The created game DTO.</returns>
    public GradeDto AddNewGrade(CreateGradeDto createdGrade, int userId);
}
