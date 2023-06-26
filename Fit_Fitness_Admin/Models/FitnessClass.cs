using System;
using Fit_Fitness_Admin.Services;

namespace Fit_Fitness_Admin
{
    public class FitnessClass
    {
        private DateTime _startTime;
        private DateTime _endTime;

        public static string FitnessClassURL = "http://localhost:3000/api/fitness_classes";
        public static int SelectedId = 0;
        public int id { get; set; }

        public string name { get; set; }
        public string location { get; set; }
        public string details { get; set; }
        public string instructorname { get; set; }
        public string instructoremail { get; set; }
        public string instructorphone { get; set; }
        public DateTime start_time
        {
            get => _startTime.ToLocalTime();
            set => _startTime = value;
        }
        public DateTime end_time
        {
            get => _endTime.ToLocalTime();
            set => _endTime = value;
        }
        public int enrollment { get; set; }
        public int capacity { get; set; }
        public int instructor_id { get; set; }
    


        public FitnessClass()
        {

        }
        public FitnessClass(string name, string location, string details, string instructorname, string instructoremail, string instructorphone, DateTime start_time, DateTime end_time, int enrollment, int capacity, int instructor_id)
        {
            this.name = name;
            this.location = location;
            this.details = details;
            this.instructorname = instructorname;
            this.instructoremail = instructoremail;
            this.instructorphone = instructorphone;
            this.start_time = start_time;
            this.end_time = end_time;
            this.enrollment = enrollment;
            this.capacity = capacity;
            this.instructor_id = instructor_id;
        }
      
    }
}

