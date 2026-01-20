using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Interfaces;
using Shared.Models.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoundingController : ControllerBase
{
    private readonly IRoundingService _service;

    public RoundingController(IRoundingService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RoundingDto>> GetAll()
    {
        var result = _service.GetAllRoundings();
        return Ok(result);
    }
}
