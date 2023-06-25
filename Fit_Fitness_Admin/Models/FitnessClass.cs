using System;
using Fit_Fitness_Admin.Services;

namespace Fit_Fitness_Admin
{
    public class FitnessClass
    {
        public static int SelectedId = 0;
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPhone { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Capacity { get; set; }
        public int Enrollment { get; set; }
        public int InstructorId { get; set; }


        public FitnessClass()
        {

        }
        public FitnessClass(int id, string name, string location, string details, string instructorName, string instructorEmail, string instructorPhone, DateTime start, DateTime end, int capacity, int enrollment, int instructorId)
        {
            Id = id;
            Name = name;
            Location = location;
            Details = details;
            InstructorName = instructorName;
            InstructorEmail = instructorEmail;
            InstructorPhone = instructorPhone;
            Start = start;
            End = end;
            Capacity = capacity;
            Enrollment = enrollment;
            InstructorId = instructorId;
        }
      
    }
}

