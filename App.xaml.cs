using Fit_Fitness_Client.Models;
namespace Fit_Fitness_Client;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

        Client.MakeClientTable();
        ClientClasses.MakeClientClassesTable();


        if (Preferences.ContainsKey("UserLoggedIn"))
        {
            MainPage = new NavigationPage(new DashboardPage());
        }
        else
        {
            MainPage = new NavigationPage(new Signin());

        }
	}
}

