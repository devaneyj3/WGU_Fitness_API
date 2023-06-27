
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

        var isClientEnrolled = Client.clientFitnessClassesList.Find((clientClass) => clientClass.id == selectedId);

        if (isClientEnrolled != null)
        {
            ReserveClass.IsVisible = false;
            infoLb.IsVisible = true;
            WithdrawalBtn.IsVisible = true;
        }
        //disable reserve button if enrolled equals cap
        if (capacity == enrollment)
        {
            ReserveClass.IsEnabled = false;
            infoLb.IsVisible = true;
            infoLb.Text = "This class is full";

        }
    }
    async void ReserveClass_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Reserve", $"Do you want to reserve a spot in {selectedName}", "Yes", "No");

        if (response == true)
        {
            //add client to class
            var addClassApiUrl = $"{Client.clientURL}/{Client.SignedInClientId}/fitness_classes/{selectedId}";
            var isAdded = DatabaseServices.AddClassToClient<object, FitnessClass>(addClassApiUrl).Data;


            //update class enrollment
            var updateClassEnrollmentApiUrl = $"{FitnessClass.FitnessClassURL}/{selectedId}/incrementAttendees";
            var isEnrollmentUpdated = DatabaseServices.UpdateEnrollment<object, FitnessClass>(updateClassEnrollmentApiUrl).Data;

            if (isAdded != null && isEnrollmentUpdated != null)
            {
                // Process the API response

                await DisplayAlert("Successfull", "Fitness class reserved", "OK");

                // Navigate to root of "Search Classes" to clear its stack:
                await Shell.Current.Navigation.PopToRootAsync();
                //await Shell.Current.GoToAsync("//searchclasses/searchpage");

                //await Shell.Current.GoToAsync("///myclasses");

            }
            else
            {
                await DisplayAlert("Error", "There was an error reserving fitness classes", "OK");
            }
        }
    }

    async void WithdrawalBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to withdraw a from {selectedName}", "Yes", "No");

        if (response == true)
        {
            //delete client from class
            var deleteClassFromClientApiUrl = $"{Client.clientURL}/{Client.SignedInClientId}/fitness_classes/{selectedId}/remove";
            var deletedClass = DatabaseServices.DeleteData<object, FitnessClass>(deleteClassFromClientApiUrl).Data;


            //update class enrollment
            var updateClassEnrollmentApiUrl = $"{FitnessClass.FitnessClassURL}/{selectedId}/decrementAttendees";
            var isEnrollmentUpdated = DatabaseServices.UpdateEnrollment<object, FitnessClass>(updateClassEnrollmentApiUrl).Data;

            if (deletedClass != null && isEnrollmentUpdated != null)
            {
                // Process the API response

                await DisplayAlert("Successfull", "You withdrew from class", "OK");


                // Navigate to root of "Search Classes" to clear its stack:
                await Shell.Current.Navigation.PopToRootAsync();
                //await Shell.Current.GoToAsync("//searchclasses/searchpage");

                //await Shell.Current.GoToAsync("///myclasses");




            }
            else
            {
                await DisplayAlert("Error", "There was an error withdrawing fitness classes", "OK");
            }
        }

    }
}

