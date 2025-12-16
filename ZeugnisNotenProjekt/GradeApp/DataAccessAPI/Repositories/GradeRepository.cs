using DataAccessAPI.Interfaces;
using Shared.Models;

namespace DataAccessAPI.Repositories;

public class GradeRepository : IGradeRepository
{
    private GradesDb _db;
    public GradeRepository(GradesDb db)
    {
        _db = db;
    }

    /// <summary>
    /// Creates the new grade.
    /// </summary>
    /// <param name="newGrade">The new grade.</param>
    /// <returns>
    /// Created game.
    /// </returns>
    public GradeT CreateNewGrade(GradeT newGrade)
    {
        if (newGrade == null)
        {
            return null;
        }
        _db.Grades.Add(newGrade);
        _db.SaveChanges();
        return newGrade;
    }
}
