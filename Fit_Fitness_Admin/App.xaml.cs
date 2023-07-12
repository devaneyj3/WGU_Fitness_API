using Fit_Fitness_Admin.Models;

namespace Fit_Fitness_Admin;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
  

        if (Preferences.ContainsKey("UserLoggedIn"))
        {
            MainPage = new NavigationPage(new DashboardPage());
        }
        else
        {
            MainPage = new NavigationPage(new MainPage());

        }



    }
}

