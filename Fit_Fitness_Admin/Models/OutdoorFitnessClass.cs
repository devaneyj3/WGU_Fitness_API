using System;
using System.ComponentModel.DataAnnotations;
namespace Fit_Fitness_Admin
{
    class OutdoorFitnessClass : FitnessClass
    {
        public string Type { get; set; }
        public OutdoorFitnessClass(string name, string location, string details, string instructorName, string instructorEmail, string instructorPhone, DateTime start, DateTime end, int capacity, int enrollment, string type, int instructorId) : base(name, location, details, instructorName, instructorEmail, instructorPhone, start, end, capacity, enrollment, instructorId)
        {
            Type = type;
        }
    }
}

