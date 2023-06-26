
using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;
using Npgsql;

namespace Fit_Fitness_Client;

partial class ClassDetail : ContentPage
{
    int selectedId = 0;
    string selectedName = "";
    int enrollment = 0;
    int capacity = 0;
    

    public ClassDetail(FitnessClass fitnessClass)
    {
        InitializeComponent();

        FitnessClass.SelectedId = fitnessClass.id;
        fitnessClassGrid.BindingContext = fitnessClass;
        selectedId = fitnessClass.id;
        selectedName = fitnessClass.name;

        capacity = fitnessClass.capacity;
        enrollment = fitnessClass.enrollment;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        //
        //bool isClientEnrolled = ClientClasses.IsEnrolled(selectedId);

        //if (isClientEnrolled)
        //{
        //    ReserveClass.IsVisible = false;
        //    infoLb.IsVisible = true;
        //    WithdrawalBtn.IsVisible = true;
        //}
        ////disable reserve button if enrolled equals cap
        //if (capacity == enrollment)
        //{
        //    ReserveClass.IsEnabled = false;
        //    infoLb.IsVisible = true;
        //    infoLb.Text = "This class is full";

        //}
    }
    async void ReserveClass_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Reserve", $"Do you want to reserve a spot in {selectedName}", "Yes", "No");

        if (response == true)
        {
            //string query = "UPDATE fitness_classes SET enrollment = enrollment + 1 WHERE id = @id";

            //var addClassToClient = "INSERT INTO client_classes(client_id, class_id) VALUES(@client_id, @class_id)";


            if (true)
            {
                await DisplayAlert("Successfull", "Fitness class reserved", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "There was an error reserving fitness classes", "OK");
            }
            await Navigation.PopAsync();

        }
    }

    async void WithdrawalBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to withdraw a from {selectedName}", "Yes", "No");

        if (response == true)
        {
            //string query = "UPDATE fitness_classes SET enrollment = enrollment - 1 WHERE id = @id";

            //var addClassToClient = "DELETE FROM client_classes WHERE client_id = @client_id AND class_id = @class_id";


           
            if (true)
            {
                await DisplayAlert("Successfull", "Withdrew from class", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "There was an error withdrawing from fitness classes", "OK");
            }
            await Navigation.PopAsync();

        }
    }
}
