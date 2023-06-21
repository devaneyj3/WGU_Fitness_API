

using System.Linq;
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


    void SignIn_Clicked(object sender, EventArgs e)
    {

        if (isValid(username.Text, password.Text))
        {

            Preferences.Set("UserLoggedIn", true);
            App.GoToMainPage();
        }
        else
        {
            DisplayAlert("Error", "Invalid Credentials", "OK");
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

    public bool isValid(string username, string password)

    {
        List<Client> clients = DatabaseServices.GetClients();

        Client client = clients.FirstOrDefault(i => i.Username == username);

        // If the client record does not exist, return false
        if (client == null)
        {
            return false;
        }
        else
        {

            Preferences.Set("SignedInClientId", client.Id);
            Preferences.Set("SignedInClientName", client.Name);
            Preferences.Set("SignedInClientEmail", client.Email);
            Preferences.Set("SignedInClientPhone", client.Phone);
        }
        // Compare the hashed password in the client record with the password provided
        return PasswordHasher.VerifyPassword(password, client.Password);
    }
}


