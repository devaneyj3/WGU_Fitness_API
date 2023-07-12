using Fit_Fitness_Client.Models;
using Microsoft.Maui.Controls;


namespace Fit_Fitness_Client;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();


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

        //for some reason i get a crash when using app shell
        try
        {
            Application.Current.MainPage = new NavigationPage(new DashboardPage());
        }
        catch (Exception ex)
        {
            // Log or display the exception details
            System.Diagnostics.Debug.WriteLine($"Exception in GoToMainPage: {ex}");
        }
    }

}

