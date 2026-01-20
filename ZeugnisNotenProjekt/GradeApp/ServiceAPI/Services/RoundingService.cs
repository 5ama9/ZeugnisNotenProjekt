using Shared.Models.DTOs;
using DataAccessAPI.Interfaces;

public class RoundingService : IRoundingService
{
    private readonly IRoundingRepository _repository;

    public RoundingService(IRoundingRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<RoundingDto> GetAllRoundings()
    {
        return _repository.GetAll()
            .Select(r => new RoundingDto
            {
                Id = r.Id,
                Name = r.Name
            });
    }
}
