
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;
using Npgsql;

namespace Fit_Fitness_Admin;

public partial class EditClass : ContentPage
{
    int idToEdit = 0;
    public EditClass(FitnessClass fitnessClass)
    {
        InitializeComponent();

        idToEdit = fitnessClass.id;
        //prepopulate form

        CourseName.Text = fitnessClass.name;

        startDatePicker.Date = fitnessClass.start_time.Date;
        startTimePicker.Time = new TimeSpan(fitnessClass.start_time.Hour, fitnessClass.start_time.Minute, 0);

        endDatePicker.Date = fitnessClass.end_time.Date;
        endTimePicker.Time = new TimeSpan(fitnessClass.end_time.Hour, fitnessClass.end_time.Minute, 0);

        LocationEntry.Text = fitnessClass.location;
        Details.Text = fitnessClass.details;
        Capacity.Text = fitnessClass.capacity.ToString();

    }
    async void Edit_Clicked(object sender, EventArgs e)
    {
        string Name = CourseName.Text;

        DateTime StartDate = startDatePicker.Date;
        TimeSpan StartTimePicker = startTimePicker.Time;
        DateTime combinedStartDateTime = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTimePicker.Hours, StartTimePicker.Minutes, StartTimePicker.Seconds);


        DateTime EndDate = endDatePicker.Date;
        TimeSpan EndTimePicker = endTimePicker.Time;
        DateTime combinedEndDateTime = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTimePicker.Hours, EndTimePicker.Minutes, EndTimePicker.Seconds);

        string location = LocationEntry.Text;
        string details = Details.Text;
        string capacityStr = Capacity.Text;

        int capacity = int.Parse(capacityStr);

        //check if values are entered
        if (string.IsNullOrWhiteSpace(Name))
        {

            await DisplayAlert("Missing Name", "Please enter a name", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(capacityStr))
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
        string query = "UPDATE fitness_classes SET name = @name, details = @details, location = @location, start_time = @starttime, end_time = @endtime, capacity = @capacity WHERE id = @Id";



        List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
        {

                new NpgsqlParameter("@name", Name),
                new NpgsqlParameter("@details", details),
                new NpgsqlParameter("@location", location),
                new NpgsqlParameter("@starttime", combinedStartDateTime), // Assuming StartDate is a DateTime object representing the start time.
                new NpgsqlParameter("endtime", combinedEndDateTime),
                new NpgsqlParameter("capacity", capacity),
                new NpgsqlParameter("Id", idToEdit)

         };



        if (true)
        {
            await DisplayAlert("Successfull", "Fitness class updated", "OK");
            await Navigation.PopToRootAsync();
        }
        else
        {
            await DisplayAlert("Error", "There was an error updating fitness classes", "OK");
        }
    }

    void Cancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}
