using Fit_Fitness_Client.Models;


namespace Fit_Fitness_Client;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

     
        Application.Current.MainPage = new AppShell();
        if (Preferences.ContainsKey("UserLoggedIn"))
        {
            GoToMainPage();
        }
        else
        {
            MainPage = new NavigationPage(new Signin());

        }


    }
     public static void GoToMainPage()
    {
        Application.Current.MainPage =  new AppShell();
    }
}

