using Shared.Models.DTOs;

namespace Web.Services;

public interface IGradeService
{
    /// <summary>
    /// Method to load the grades
    /// </summary>
    /// <returns>the list of grades</returns>
    Task<List<GradeDto>> GetAsync();

    /// <summary>
    /// Method to Add new grades
    /// </summary>
    /// <param name="newGrade">the new grade created</param>
    /// <returns>success code</returns>
    Task AddAsync(GradeDto newGrade);

    /// <summary>
    /// Method to get/ load the Roundings from the API
    /// </summary>
    /// <returns>the found roundings</returns>
    Task<List<RoundingDto>> GetRoundingsAsync();
}
