﻿using System;
using Fit_Fitness_Admin.Services;
namespace Fit_Fitness_Admin.Models
{
    public class Instructor
        
    {
        public static string InstructorURL = $"{DatabaseConnection.ConnectionURL}instructors";
        public static int SignedInInstructorId { get; set; }
        public static string SignedInInstructorName { get; set; }
        public static string SignedInInstructorEmail { get; set; }
        public static string SignedInInstructorPhone { get; set; }

        public int id { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        

        public Instructor() {}
        public Instructor(string name, string email, string phone, string username,
                          string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
        }
    }
}
