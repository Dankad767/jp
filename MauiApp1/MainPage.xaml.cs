using Microsoft.Maui.Controls;

namespace MauiApp1.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); // Ensure this line is present
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HiraganaPage");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("KatakanaPage");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HiraganaCharsPage");
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("KatakanaCharsPage");
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ResultsPage");
        }
    }
}
