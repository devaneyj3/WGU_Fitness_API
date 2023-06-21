using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();




        //all fitness classes
        List<FitnessClass> fitnessClassesList = DatabaseServices.GetFitnessClasses("fitness_classes");

        cCollectionView.ItemsSource = fitnessClassesList;

        // change label text based on class list count
        if (fitnessClassesList.Count > 0)
        {
            clHeaderLb.Text = $"There are {fitnessClassesList.Count} classes";
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

}
