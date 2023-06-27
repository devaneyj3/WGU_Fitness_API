namespace Fit_Fitness_Client;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();
    }
    async void OnSignOutClicked(object sender, EventArgs e)
    {
        {
            bool response = await DisplayAlert("Sign Out", $"Are you sure you want to sign out?", "Yes", "No");

            if (response == true)
            {
                Preferences.Clear();
                Application.Current.MainPage = new NavigationPage(new Signin());

            }
        }
    }
}

