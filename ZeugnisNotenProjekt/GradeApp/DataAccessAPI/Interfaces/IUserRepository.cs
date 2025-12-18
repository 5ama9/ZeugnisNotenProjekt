using Shared.Models;

namespace DataAccessAPI.Interfaces;

public interface IUserRepository
{
    public User? GetByEmailAndPassword(string email, string password);
}
