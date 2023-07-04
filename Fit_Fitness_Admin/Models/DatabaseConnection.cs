using System;
namespace Fit_Fitness_Admin.Models
{
	public class DatabaseConnection
	{
        public static string ConnectionURL = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production" ? "https://evening-fjord-36308-0a2e1a3701c3.herokuapp.com/api/" : "http://localhost:3000/api/";

    }
}

