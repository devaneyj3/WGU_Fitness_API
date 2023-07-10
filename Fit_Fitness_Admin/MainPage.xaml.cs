
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;

namespace Fit_Fitness_Admin;

public partial class MainPage : ContentPage
{
    private ApiService apiService;
    public MainPage()
    {
        InitializeComponent();
        Preferences.Clear();
        apiService = new ApiService();
    }


    async void SignIn_Clicked(object sender, EventArgs e)
    {
        var apiUrl = $"{Instructor.InstructorURL}/login";
        try
        {
            var obj = new { username = username.Text, password = password.Text };


            var instructor = apiService.PostData<object, Instructor>(apiUrl, obj).Data;
            if (instructor != null)
            {

                Preferences.Set("SignedInInstructorId", instructor.id);
                Preferences.Set("SignedInInstructorName", instructor.Name);
                Preferences.Set("SignedInInstructorEmail", instructor.Email);
                Preferences.Set("SignedInInstructorPhone", instructor.Phone);

                Preferences.Set("UserLoggedIn", true);
                await Navigation.PushAsync(new DashboardPage());
            }


        }
        catch (Exception)
        {
            await DisplayAlert("Error", " User not found", "OK");
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



