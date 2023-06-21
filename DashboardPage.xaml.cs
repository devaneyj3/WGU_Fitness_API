using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();


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
            welcomeLb.Text = $"Welcome {Client.SignedInClientName}!";

        }
        else
        {
            Preferences.Clear();
            Application.Current.MainPage = new NavigationPage(new Signin());
        }


        //all fitness classes
        List<FitnessClass> fitnessClassesList = DatabaseServices.GetFitnessClasses("fitness_classes");

        //
        List<FitnessClass> clientFitnessClassesList = ClientClasses.GetClientClasses();
        cListView.ItemsSource = clientFitnessClassesList;

        // change label text based on class list count
        if (fitnessClassesList.Count > 0)
        {
            clHeaderLb.Text = $"There are {fitnessClassesList.Count} total classes";
        }
        else
        {
            clHeaderLb.Text = "There are no classes";
        }



    }

    async void cListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {

            var fitnessClass = e.SelectedItem as FitnessClass;



            await Navigation.PushAsync(new ClassDetail(fitnessClass));

        }
        cListView.SelectedItem = null;
    }



    async void SignOut_Clicked(object sender, EventArgs e)
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
