
using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;

namespace Fit_Fitness_Client;

partial class ClassDetail : ContentPage
{
    int selectedId = 0;
    string selectedName = "";

    public ClassDetail(FitnessClass fitnessClass)
    {
        InitializeComponent();

        FitnessClass.SelectedId = fitnessClass.Id;
        ClassView.BindingContext = fitnessClass;
        selectedId = fitnessClass.Id;
        selectedName = fitnessClass.Name;
    }



    async void ReserveClass_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to reserve a spot in {selectedName}", "Yes", "No");

        //if (response == true)
        //{
        //    string query = $"DELETE FROM fitness_classes WHERE id ={selectedId}";
        //    bool isSucessfull = DatabaseServices.Remove(query);

        //    if (isSucessfull)
        //    {
        //        await DisplayAlert("Successfull", "Fitness class reserved", "OK");
        //        await Navigation.PopAsync();
        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "There was an error reserving fitness classes", "OK");
        //    }
        //    await Navigation.PopAsync();

        //}
    }
}
