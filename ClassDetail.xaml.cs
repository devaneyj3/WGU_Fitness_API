
using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;
using Npgsql;

namespace Fit_Fitness_Client;

partial class ClassDetail : ContentPage
{
    int selectedId = 0;
    string selectedName = "";
    int enrollment = 0;

    public ClassDetail(FitnessClass fitnessClass)
    {
        InitializeComponent();

        FitnessClass.SelectedId = fitnessClass.Id;
        ClassView.BindingContext = fitnessClass;
        selectedId = fitnessClass.Id;
        selectedName = fitnessClass.Name;
        enrollment = fitnessClass.Enrollment;
    }



    async void ReserveClass_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to reserve a spot in {selectedName}", "Yes", "No");

        if (response == true)
        {
            Console.WriteLine(enrollment.ToString());
            enrollment++;
            Console.WriteLine(enrollment.ToString());
            string query = "UPDATE fitness_classes SET enrollment = enrollment + 1 WHERE id = @id";


            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
            new NpgsqlParameter("@id", FitnessClass.SelectedId),

            };
            bool isSucessfull = DatabaseServices.ReserveClass(query);

            if (isSucessfull)
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
}
