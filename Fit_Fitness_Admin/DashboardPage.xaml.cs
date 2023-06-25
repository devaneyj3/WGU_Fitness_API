using System.Collections;
using System.Collections.Generic;
using Fit_Fitness_Admin.Models;
using Fit_Fitness_Admin.Services;
using Microsoft.Maui.Controls;

namespace Fit_Fitness_Admin;

public partial class DashboardPage : ContentPage
{
    List<FitnessClass> fitnessClassesList = new List<FitnessClass>();
    public DashboardPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        
        if (Preferences.ContainsKey("SignedInInstructorName"))
        {
           string name = Preferences.Get("SignedInInstructorName", string.Empty);
           string id = Preferences.Get("SignedInInstructorId", string.Empty);
           string email = Preferences.Get("SignedInInstructorEmail", string.Empty);
           string phone = Preferences.Get("SignedInInstructorPhone", string.Empty);

            Instructor.SignedInInstructorId = int.Parse(id);
            Instructor.SignedInInstructorName = name;
            Instructor.SignedInInstructorEmail = email;
            Instructor.SignedInInstructorPhone = phone;
            welcomeLb.Text = $"Welcome {Instructor.SignedInInstructorName}!";

        }
        else
        {
            Preferences.Clear();
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }




       //fitnessClassGrid.ItemsSource = fitnessClassesList;

        // change label text based on class list count
         if ( fitnessClassesList.Count > 0)
        {
            clHeaderLb.Text = $"You are currently teaching {fitnessClassesList.Count} classes";
        }
        else
        {
            clHeaderLb.Text = "You are not teaching any classes";
        }



    }

    async void cCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is FitnessClass fitnessClass)
        {

            await Navigation.PushAsync(new ClassDetail(fitnessClass));

        }
        fitnessClassGrid.SelectedItem = null;
    }


    async void AddClass_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddClassPage());
    }

    async void SignOut_Clicked(object sender, EventArgs e)
    {
        {
            bool response = await DisplayAlert("Sign Out", $"Are you sure you want to sign out?", "Yes", "No");

            if (response == true)
            {
                Preferences.Clear();
                Application.Current.MainPage = new NavigationPage(new MainPage());

            }
        }
    }
    void SearchBar_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var searchTerm = SearchBarEntry.Text.ToUpper();
        fitnessClassGrid.ItemsSource = fitnessClassesList.FindAll((fc => fc.Name.ToUpper().Contains(searchTerm)));
    }
}
