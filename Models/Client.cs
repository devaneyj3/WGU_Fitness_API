using System;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client.Models
{
	public class Client
	{
        public static int SignedInClientId = 0;
        public static string SignedInClientName = "";
        public static string SignedInClientEmail = "";
        public static string SignedInClientPhone = "";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Client(int id, string name, string email, string phone, string username, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password; //Encrypt before production

        }
        public static void MakeClientTable()
        {
            string createTableQuery = @"
                 CREATE TABLE IF NOT EXISTS Clients (
                     Id SERIAL PRIMARY KEY,
                     name VARCHAR(100) NOT NULL,
                     email VARCHAR(100) NOT NULL,
                     phone VARCHAR(100) NOT NULL,
                     username VARCHAR(100) NOT NULL,
                     password VARCHAR(100) NOT NULL
                 )";
            DatabaseServices.Create(createTableQuery);
        }
    }
}

