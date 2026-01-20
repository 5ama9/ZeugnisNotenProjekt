using DataAccessAPI.Interfaces;
using Shared.Models;

namespace DataAccessAPI.Repositories;

public class RoundingRepository : IRoundingRepository
{
    private readonly GradesDb _context;

    public RoundingRepository(GradesDb context)
    {
        _context = context;
    }

    public IEnumerable<Rounding> GetAll()
    {
        return _context.Roundings.ToList();
    }
}
