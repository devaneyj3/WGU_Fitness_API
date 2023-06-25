using System;
namespace Fit_Fitness_Admin.Models;
using BCrypt;
using System.Text;

public static class PasswordHasher
{

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}

