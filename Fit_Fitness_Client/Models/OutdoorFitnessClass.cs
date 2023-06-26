using System;
namespace Fit_Fitness_Client.Models
{
    class OutdoorFitnessClass : FitnessClass
    {
        public string Type { get; set; }
        public OutdoorFitnessClass(int Id, string name, string location, string details, string instructorName, string instructorEmail, string instructorPhone, DateTime start, DateTime end, int capacity, int enrollment, string type, int instructorId) : base(name, location, details, instructorName, instructorEmail, instructorPhone, start, end, capacity, enrollment, instructorId)
        {
            Type = type;
        }
    }
}

