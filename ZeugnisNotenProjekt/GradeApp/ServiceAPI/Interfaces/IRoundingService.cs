using Shared.Models.DTOs;

public interface IRoundingService
{
    IEnumerable<RoundingDto> GetAllRoundings();
}
