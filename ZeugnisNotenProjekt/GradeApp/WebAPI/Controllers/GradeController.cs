using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Interfaces;
using Shared.Models.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Authorize]
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
    }
}
