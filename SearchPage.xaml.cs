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

        cListView.ItemsSource = fitnessClassesList;

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

    async void cListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {

            var fitnessClass = e.SelectedItem as FitnessClass;



            await Navigation.PushAsync(new ClassDetail(fitnessClass));

        }
        cListView.SelectedItem = null;
    }

}
