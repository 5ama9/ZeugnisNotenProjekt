using Shared.Models;

namespace DataAccessAPI.Interfaces;

public interface IGradeRepository
{
    public GradeT CreateNewGrade(GradeT newGrade);
}
