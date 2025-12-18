using DataAccessAPI.Interfaces;
using Shared.Models;

namespace DataAccessAPI.Repositories;

public class UserRepository : IUserRepository
{
    private GradesDb _db;
    public UserRepository(GradesDb db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets the user by email and password.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="password">The password.</param>
    /// <returns>null if user or his password is wrong, found user if right.</returns>
    public User? GetByEmailAndPassword(string email, string password)
    {
        var user = _db.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        if (user.Password != password)
        {
            return null;
        }
        return user;
    }
}
