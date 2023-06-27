using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

public partial class DashboardPage : ContentPage
{
    List<FitnessClass> clientFitnessClassesList = new List<FitnessClass>();
    public DashboardPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (clientFitnessClassesList.Count > 0)
        {

            clHeaderLb.Text = $"You are enrolled in {clientFitnessClassesList.Count} classes";
        }
        else
        {
            clHeaderLb.Text = "You are not enrolled in any classes";
        }

        if (Preferences.ContainsKey("SignedInClientName"))
        {
            string name = Preferences.Get("SignedInClientName", string.Empty);
            string id = Preferences.Get("SignedInClientId", string.Empty);
            string email = Preferences.Get("SignedInClientEmail", string.Empty);
            string phone = Preferences.Get("SignedInClientPhone", string.Empty);

            Client.SignedInClientId = int.Parse(id);
            Client.SignedInClientName = name;
            Client.SignedInClientEmail = email;
            Client.SignedInClientPhone = phone;
            welcomeLb.Text = $"Welcome {name}";

        }
        else
        {
            Preferences.Clear();
            Application.Current.MainPage = new NavigationPage(new Signin());
        }


        var apiUrl = $"{Client.clientURL}/{Client.SignedInClientId}/fitness_classes";
        try
        {
            var fitnessClassListResponse = DatabaseServices.GetData<object, FitnessClass>(apiUrl);

            // change label text based on class list count
            if (fitnessClassListResponse != null)
            {
                clientFitnessClassesList = fitnessClassListResponse.Data;
                cCollectionView.ItemsSource = clientFitnessClassesList;
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }
    }

    void cCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)

    {
        if (e.CurrentSelection.FirstOrDefault() is FitnessClass fitnessClass)
        {

            Navigation.PushAsync(new ClassDetail(fitnessClass));

        }
        cCollectionView.SelectedItem = null;
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

    void searchBar_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var searchTerm = searchBar.Text.ToUpper();

        cCollectionView.ItemsSource = clientFitnessClassesList.FindAll((fc => fc.name.ToUpper().Contains(searchTerm)));
    }
}
