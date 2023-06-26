using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

public partial class SearchPage : ContentPage
{
    //all fitness classes

    List<FitnessClass> clientFitnessClassesList = new List<FitnessClass>();
    public SearchPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var apiUrl = $"{FitnessClass.FitnessClassURL}";
        try
        {
            var fitnessClassListResponse = DatabaseServices.GetData<object, FitnessClass>(apiUrl);


            // change label text based on class list count
            if (fitnessClassListResponse != null)
            {
                clientFitnessClassesList = fitnessClassListResponse.Data;


                clHeaderLb.Text = $"There are {clientFitnessClassesList.Count} classes with open spots";
                cCollectionView.ItemsSource = clientFitnessClassesList;
            }
            else
            {
                clHeaderLb.Text = $"There are {clientFitnessClassesList.Count} classes with open spots";
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

    void searchBar_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var searchTerm = searchBar.Text.ToUpper();

        cCollectionView.ItemsSource = clientFitnessClassesList.FindAll((fc => fc.name.ToUpper().Contains(searchTerm)));
    }
}
