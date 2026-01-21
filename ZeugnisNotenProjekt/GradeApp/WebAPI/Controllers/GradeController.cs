using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Interfaces;
using ServiceAPI.Services;
using Shared.Models.DTOs;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class GradeController : ControllerBase
{
    IGradeService _service;
    public GradeController(IGradeService service)
    {
        _service = service;
    }

    /// <summary>
    /// Creates the new grade.
    /// </summary>
    /// <param name="createdGrade">The created grade.</param>
    /// <returns>Created() 201, the created game and its location if successfully created, BadRequest() 400 if null.</returns>
    [HttpPost]
    public ActionResult<GradeDto> CreateNewGrade(CreateGradeDto createdGrade)
    {
        string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        GradeDto result = _service.AddNewGrade(createdGrade, int.Parse(id));
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    /// <summary>
    /// Gets grades by user identifier.
    /// </summary>
    /// <param name="id">The user dentifier from JWT.</param>
    /// <returns>Ok 200 and collection of grades if not null. Else Not Found.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<GradeDto>> GetGradesByUserId()
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            return Unauthorized();
        }

        IEnumerable<GradeDto> grades = _service.GetGradesByUserId(int.Parse(userId));

        return Ok(grades);
    }

    /// <summary>
    /// Updates the status of the grade by identifier.
    /// </summary>
    /// <param name="updatedGrade">The updated grade.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// 200 Ok() and the updated grade dto if successful, 403 Forbidden() if null.
    /// </returns>
    [HttpPut("{id}")]
    public ActionResult<GradeDto> UpdateGradeStatusById(UpdateGradeDto updatedGrade, int id)
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        int result = _service.UpdateGradeStatusById(updatedGrade, id, int.Parse(userId));
        if (result == 0)
        {
            return Forbid();
        }
        return Ok(result);
    }
}
