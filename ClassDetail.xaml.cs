
using Fit_Fitness_Client.Models;
using Fit_Fitness_Client.Services;
using Npgsql;

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

        //
        bool isClientEnrolled = ClientClasses.IsEnrolled(fitnessClass.Id);

        if (isClientEnrolled)
        {
            ReserveClass.IsVisible = false;
            enrolledLb.IsVisible = true;
            WithdrawalBtn.IsVisible = true;
        }
    }



    async void ReserveClass_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to withdraw from {selectedName}", "Yes", "No");

        if (response == true)
        {
            string query = "UPDATE fitness_classes SET enrollment = enrollment + 1 WHERE id = @id";

            var addClassToClient = "INSERT INTO client_classes(client_id, class_id) VALUES(@client_id, @class_id)";


            List<NpgsqlParameter> classToClientParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@client_id", Client.SignedInClientId),
                new NpgsqlParameter("@class_id", FitnessClass.SelectedId)

            };
            DatabaseServices.ExecuteNonQuery(addClassToClient, classToClientParameters);
            List<NpgsqlParameter> ReserveParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@id", FitnessClass.SelectedId),

            };
            bool isSucessfull = DatabaseServices.ExecuteNonQuery(query, ReserveParameters);

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

    async void WithdrawalBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to reserve a spot in {selectedName}", "Yes", "No");

        if (response == true)
        {
            string query = "UPDATE fitness_classes SET enrollment = enrollment - 1 WHERE id = @id";

            var addClassToClient = "DELETE FROM client_classes WHERE client_id = @client_id AND class_id = @class_id";


            List<NpgsqlParameter> classToClientParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@client_id", Client.SignedInClientId),
                new NpgsqlParameter("@class_id", FitnessClass.SelectedId)

            };
            DatabaseServices.ExecuteNonQuery(addClassToClient, classToClientParameters);
            List<NpgsqlParameter> ReserveParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@id", FitnessClass.SelectedId),

            };
            bool isSucessfull = DatabaseServices.ExecuteNonQuery(query, ReserveParameters);

            if (isSucessfull)
            {
                await DisplayAlert("Successfull", "Withdrwaled from class", "OK");
                ReserveClass.IsVisible = true;
                enrolledLb.IsVisible = false;
                WithdrawalBtn.IsVisible = false;
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "There was an error withdrawaling from fitness classes", "OK");
            }
            await Navigation.PopAsync();

        }
    }
}
