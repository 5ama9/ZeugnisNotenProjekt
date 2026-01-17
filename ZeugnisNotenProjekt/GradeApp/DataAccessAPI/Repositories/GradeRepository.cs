using System.Diagnostics;
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

    /// <summary>
    /// Updates the status of the grade by identifier.
    /// </summary>
    /// <param name="updatedGrade">The updated grade.</param>
    /// <returns>
    /// Updated grade as model.
    /// </returns>
    public void UpdateGradeStatusById(GradeT updatedGrade)
    {
        _db.Grades.Update(updatedGrade);
        _db.SaveChanges();
    }

    /// <summary>
    /// Gets the grade by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// The found game.
    /// </returns>
    public GradeT GetGradeById(int id)
    {
        GradeT foundGrade = _db.Grades.Find(id);
        if (foundGrade == null)
        {
            return null;
        }
        return foundGrade;
    }
}
