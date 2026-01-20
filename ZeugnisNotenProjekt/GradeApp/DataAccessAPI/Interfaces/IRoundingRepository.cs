using Shared.Models;

namespace DataAccessAPI.Interfaces;

public interface IRoundingRepository
{
    IEnumerable<Rounding> GetAll();
}
