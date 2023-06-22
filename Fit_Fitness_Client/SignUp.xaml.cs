
using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;
using Npgsql;


namespace Fit_Fitness_Client;

public partial class SignUp : ContentPage
{
    public SignUp()
    {
        InitializeComponent();
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

        // Hash the password with the salt
        string hashedPassword = PasswordHasher.HashPassword(password);

        string query = "INSERT INTO Clients (name, phone, email, username, password) VALUES (@name, @phone, @email, @username, @hashedPassword)";

        List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
        {
            new NpgsqlParameter("@name", name),
            new NpgsqlParameter("@phone", phone),
            new NpgsqlParameter("@email", email),
            new NpgsqlParameter("@username", username),
            new NpgsqlParameter("@hashedPassword", hashedPassword)
        };

        bool isSeccesful = DatabaseServices.ExecuteNonQuery(query, parameters);

        if (isSeccesful)
        {
            await DisplayAlert("Successfull", "User created", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "There was an error creating user", "OK");
        }


    }
}
