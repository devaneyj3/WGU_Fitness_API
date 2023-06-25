
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;
using Newtonsoft.Json;

namespace Fit_Fitness_Admin;

public partial class MainPage : ContentPage
{
    private ApiService databaseService;
    public MainPage()
    {
        InitializeComponent();
        Preferences.Clear();
        databaseService = new ApiService();
    }


    async void SignIn_Clicked(object sender, EventArgs e)
    {
        var apiUrl = "http://localhost:3000/api/instructors/login";
        try
        {
            var obj = new { username = username.Text, password = password.Text };


            var instructor = databaseService.PostData<object, Instructor>(apiUrl, obj).Data;
            if (instructor != null)
            {

                Preferences.Set("SignedInInstructorId", instructor.id);
                Preferences.Set("SignedInInstructorName", instructor.Name);
                Preferences.Set("SignedInInstructorEmail", instructor.Email);
                Preferences.Set("SignedInInstructorPhone", instructor.Phone);

                Preferences.Set("UserLoggedIn", true);
                await Navigation.PushAsync(new DashboardPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid Credentials", "OK");
            }


        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }
    }
    void Username_Completed(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(username.Text))
        {
            DisplayAlert("Username Error", "You need to enter a username", "OK");
        }
    }

    void Password_Completed(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(password.Text))
        {
            DisplayAlert("Password Error", "You need to enter a password", "OK");
        }
    }


    void SignUp_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SignUp());
    }
}



