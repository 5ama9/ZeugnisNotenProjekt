using DataAccessAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    /// Created grade.
    /// </returns>
    public GradeT CreateNewGrade(GradeT newGrade)
    {
        if (newGrade == null)
        {
            return null;
        }
        _db.Grades.Add(newGrade);
        _db.SaveChanges();
        return _db.Grades
        .Include(g => g.Approver)
        .Include(g => g.Creator)
        .Include(g => g.Status)
        .Include(g => g.Rounding)
        .FirstOrDefault(g => g.Id == newGrade.Id);
    }

    /// <summary>
    /// Gets grades by user identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// Collection of Grade models.
    /// </returns>
    public IEnumerable<GradeT> GetGradesByUserId(int id)
    {
        return _db.Grades
                .Include(g => g.Creator)
                .Include(g => g.Approver)
                .Include(g => g.Status)
                .Include(g => g.Rounding)
                .Where(g => g.ApproverId == id);
    }
}
