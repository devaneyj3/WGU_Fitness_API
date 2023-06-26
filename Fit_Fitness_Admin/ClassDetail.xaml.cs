using Fit_Fitness_Admin.Services;

namespace Fit_Fitness_Admin;

partial class ClassDetail : ContentPage
{
    int selectedId = 0;
    string selectedName = "";
    FitnessClass fClass = null;
    private ApiService apiService;



    public ClassDetail(FitnessClass fitnessClass)
    {
        InitializeComponent();

        FitnessClass.SelectedId = fitnessClass.id;
        fitnessClassGrid.BindingContext = fitnessClass;
        selectedId = fitnessClass.id;
        selectedName = fitnessClass.name;
        fClass = fitnessClass;

        apiService = new ApiService();
    }

    async void EditClass_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditClass(fClass));
    }

    async void DeleteClass_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Delete", $"Do you want to delete {selectedName}", "Yes", "No");

        if (response == true)
        {
            var apiUrl = $"{FitnessClass.FitnessClassURL}/{selectedId}";
            try
            {
                var deletedClass = apiService.DeleteData<object, FitnessClass>(apiUrl);


                // change label text based on class list count
                if (deletedClass != null)
                {
                    await DisplayAlert("Successfull", "Fitness class deleted", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "There was an error deleting fitness classes", "OK");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
