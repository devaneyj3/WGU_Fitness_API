
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;

namespace Fit_Fitness_Admin;

public partial class SignUp : ContentPage
{
    private ApiService apiService;
    public SignUp()
    {
        InitializeComponent();
        apiService = new ApiService();
    }


    void Phone_Completed(Object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Phone.Text))
        {
            DisplayAlert("Phone Error", "You need to enter a phone number", "OK");
        }
    }

    void Email_Completed(Object sender, System.EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Email.Text))
        {
            DisplayAlert("Email Error", "You need to enter an email", "OK");
        }
    }

    void Name_Completed(Object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Name.Text))
        {
            DisplayAlert("Name Error", "You need to enter a name", "OK");
        }
    }

    void Username_Completed(Object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Username.Text))
        {
            DisplayAlert("Username Error", "You need to enter a username", "OK");
        }
    }


    void Password_Completed(Object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Password.Text))
        {
            DisplayAlert("Password Error", "You need to enter a password", "OK");
        }
    }

    async void SignUp_Clicked(Object sender, EventArgs e)
    {
        string name = Name.Text;
        string email = Email.Text;
        string phone = Phone.Text;
        string password = Password.Text;
        string username = Username.Text;

        var apiUrl = $"{Instructor.InstructorURL}/register";

        var instructor = new { name, email, phone, username, password };

        try {
        var response = apiService.PostData<object, Instructor>(apiUrl, instructor).Data;

        if (response != null)
        {
            // Process the API response

            await DisplayAlert("Successfull", "User created", "OK");
            await Navigation.PopAsync();

        }
   
        } catch(Exception) {
        }
            await DisplayAlert("Error", "You need to fill in all the fields", "OK");
    }
}
