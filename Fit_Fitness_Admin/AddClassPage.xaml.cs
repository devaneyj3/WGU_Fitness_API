using System.Linq.Expressions;
using DotNetEnv;
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;
using Microsoft.Maui.Controls;
using Npgsql;

namespace Fit_Fitness_Admin;

public partial class AddClassPage : ContentPage
{

    public AddClassPage()
    {
        InitializeComponent();


    }
    async void SaveCourse_Clicked(object sender, EventArgs e)
    {
        var apiService = new ApiService();
        var apiUrl = "https://localhost:3000/api/instructors";
        var requestData = new { Name = "John", Age = 30 }; // Request data object

        //var response = apiService.PostData<object, Instructor>(apiUrl, requestData);
        //if (response != null)
        //{
        //    // Process the API response
        //    Console.WriteLine($"API response: {response}");
        //}


        string Name = CourseName.Text;

        DateTime StartDate = startDatePicker.Date;
        TimeSpan StartTimePicker = startTimePicker.Time;
        DateTime combinedStartDateTime = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTimePicker.Hours, StartTimePicker.Minutes, StartTimePicker.Seconds);


        DateTime EndDate = endDatePicker.Date;
        TimeSpan EndTimePicker = endTimePicker.Time;
        DateTime combinedEndDateTime = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTimePicker.Hours, EndTimePicker.Minutes, EndTimePicker.Seconds);

        string location = LocationEntry.Text;
        string details = Details.Text;
        string capacity = Capacity.Text;

        //check if values are entered
        if (string.IsNullOrWhiteSpace(Name))
        {

            await DisplayAlert("Missing Name", "Please enter a name", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(capacity))
        {
            await DisplayAlert("Missing capacity", "Please enter the course's capacity", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(location))
        {
            await DisplayAlert("Missing location", "Please enter the course's location", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(details))
        {
            await DisplayAlert("Missing details", "Please enter the Course's Details", "OK");
            return;
        }

        if (combinedEndDateTime < combinedStartDateTime)
        {
            await DisplayAlert("Error", "The End Date can't be before the Start Date", "OK");
            return;
        }
        string query = "INSERT INTO fitness_classes (name, details, location, start_time, end_time, instructorname, instructorphone, instructoremail, capacity, enrollment, instructor_id) VALUES (@name, @details, @location, @start_time, @end_time, @instructorname, @instructorphone, @instructoremail, @capacity, 0, @instructor_id)";

        List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
        {
        new NpgsqlParameter("@name", Name),
        new NpgsqlParameter("@details", details),
        new NpgsqlParameter("@location", location),
        new NpgsqlParameter("@start_time", combinedStartDateTime),
        new NpgsqlParameter("@end_time", combinedEndDateTime),
        new NpgsqlParameter("@instructorname", Instructor.SignedInInstructorName),
        new NpgsqlParameter("@instructorphone", Instructor.SignedInInstructorPhone),
        new NpgsqlParameter("@instructoremail", Instructor.SignedInInstructorEmail),
        new NpgsqlParameter("@capacity", int.Parse(capacity)),
        new NpgsqlParameter("@instructor_id", Instructor.SignedInInstructorId)
    };

        try
        {


            if (true)
            {
                await DisplayAlert("Successfull", "Fitness class created", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "There was an error creating fitness classes", "OK");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("The error is ", err.ToString());
        }


    }

    async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
