using System.Diagnostics;
using Shared.Models;

namespace DataAccessAPI.Interfaces;

public interface IGradeRepository
{
    /// <summary>
    /// Creates the new grade.
    /// </summary>
    /// <param name="newGrade">The new grade.</param>
    /// <returns>
    /// Created grade.
    /// </returns>
    public GradeT CreateNewGrade(GradeT newGrade);

    /// <summary>
    /// Gets grades by user identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// Collection of Grade models.
    /// </returns>
    public IEnumerable<GradeT> GetGradesByUserId(int id);

    /// <summary>
    /// Updates the status of the grade by identifier.
    /// </summary>
    /// <param name="updatedGrade">The updated grade.</param>
    /// <returns>
    /// Updated grade as model.
    /// </returns>
    public void UpdateGradeStatusById(GradeT updatedGrade);

    /// <summary>
    /// Gets the grade by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// The found grade.
    /// </returns>
    public GradeT GetGradeById(int id);
}
