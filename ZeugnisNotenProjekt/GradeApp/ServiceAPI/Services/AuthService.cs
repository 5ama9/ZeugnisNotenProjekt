using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataAccessAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAPI.Interfaces;
using Shared.Models;
using Shared.Models.DTOs;

namespace ServiceAPI.Services;

public class AuthService : IAuthService
{
    IUserRepository _userRepository;
    IConfiguration _configuration;
    public AuthService(IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _configuration = config;
    }

    public LoginResponseDto? Login(LoginRequestDto loginRequest)
    {
        User? user = _userRepository.GetByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }
        return new LoginResponseDto { Token = GenerateJwtToken(user) };
    }

    private string GenerateJwtToken(User user)
    {
        JwtSecurityTokenHandler tokenHandler = new
            JwtSecurityTokenHandler();


        byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        Claim[] claims = new[]
        {
    new Claim(JwtRegisteredClaimNames.Sub,
        user.Id.ToString()),
    new Claim(JwtRegisteredClaimNames.Email, user.Email),
    new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)
};

        SecurityTokenDescriptor tokenDescriptor = new
            SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
