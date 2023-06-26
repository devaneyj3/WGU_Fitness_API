using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

public partial class Signin: ContentPage
{

    public Signin()
    {
        InitializeComponent();
        Preferences.Clear();
    }


   async void SignIn_Clicked(object sender, EventArgs e)
    {
        var apiUrl = $"{Client.clientURL}/login";
        try
        {
            var obj = new { username = username.Text, password = password.Text };


            var client = DatabaseServices.PostData<object, Client>(apiUrl, obj).Data;
            if (client != null)
            {

                Preferences.Set("SignedInClientId", client.id);
                Preferences.Set("SignedInClientName", client.name);
                Preferences.Set("SignedInClientEmail", client.email);
                Preferences.Set("SignedInClientPhone", client.phone);

                Preferences.Set("UserLoggedIn", true);
                App.GoToMainPage();
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


