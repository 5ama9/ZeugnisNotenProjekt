using System.Diagnostics;
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

    /// <summary>
    /// Gets grades by user identifier.
    /// </summary>
    /// <param name="id">The user identifier from JWT.</param>
    /// <returns>Collection of GradeDtos.</returns>
    public IEnumerable<GradeDto> GetGradesByUserId(int id);

    /// <summary>
    /// Updates the status of the grade by identifier.
    /// </summary>
    /// <param name="updatedGrade">The updated grade.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// 1 if success, 0 if not.
    /// </returns>
    public int UpdateGradeStatusById(UpdateGradeDto updatedGrade, int id, int userId);
}
