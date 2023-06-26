
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;

namespace Fit_Fitness_Admin;

public partial class AddClassPage : ContentPage
{
    ApiService ApiService;
    public AddClassPage()
    {
        InitializeComponent();

        ApiService = new ApiService();

    }
    async void SaveCourse_Clicked(object sender, EventArgs e)
    {
        string name = CourseName.Text;
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
        if (string.IsNullOrWhiteSpace(name))
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

        var apiUrl = $"{Instructor.InstructorURL}/{Instructor.SignedInInstructorId}/fitness_classes";
        var requestData = new
        {
            name = name,
            details = details,
            location = location,
            instructorname = Instructor.SignedInInstructorName,
            instructoremail = Instructor.SignedInInstructorEmail,
            instructorphone = Instructor.SignedInInstructorPhone,
            start_time = combinedStartDateTime,
            end_time = combinedEndDateTime,
            capacity = int.Parse(capacity),
            enrollment = 0,
            instructor_id = Instructor.SignedInInstructorId
        };
        Console.WriteLine(requestData);
        var response = ApiService.PostData<object, FitnessClass>(apiUrl, requestData).Data;
        try
        {
            if (response != null)
            {
            //6 / 26 / 2023 12:00:00 AM in 2023 - 06 - 25T13: 45:30 format
                // Process the API response
                Console.WriteLine($"API response: {response}");
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
