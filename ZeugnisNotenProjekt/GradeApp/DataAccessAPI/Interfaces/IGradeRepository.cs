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
}
