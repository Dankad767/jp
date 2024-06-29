using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp1.zakladki
{
    public partial class AllUsersPage : ContentPage
    {
        private PointsActions _database;

        // Parameterless constructor
        public AllUsersPage()
        {
            InitializeComponent();
        }

        // Constructor with parameters
        public AllUsersPage(PointsActions database) : this()
        {
            _database = database;
            LoadUsers();
        }

        private async void LoadUsers()
        {
            List<User> users = await _database.GetPointsAsync();
            UsersListView.ItemsSource = users;
        }

        private async void OnDeleteAllUsersClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Delete All Users", "Are you sure you want to delete all users?", "Yes", "No");
            if (confirm)
            {
                List<User> users = await _database.GetPointsAsync();
                foreach (var user in users)
                {
                    await _database.DeleteItemAsync(user);
                }

                // Reload users after deletion
                LoadUsers();

                await DisplayAlert("Deleted", "All users deleted successfully.", "OK");
            }
        }
    }
}
