using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

public partial class SearchPage : ContentPage
{
    //all fitness classes
    List<FitnessClass> fitnessClassesList = DatabaseServices.GetOpenFitnessClasses("fitness_classes");
    public SearchPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();


        cCollectionView.ItemsSource = fitnessClassesList;

        // change label text based on class list count
        if (fitnessClassesList.Count > 0)
        {
            clHeaderLb.Text = $"There are {fitnessClassesList.Count} classes with open spots";
        }
        else
        {
            clHeaderLb.Text = "There are no classes";
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
        
        cCollectionView.ItemsSource = fitnessClassesList.FindAll((fc => fc.Name.ToUpper().Contains(searchTerm)));
    }
}
