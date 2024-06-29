namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes
            Routing.RegisterRoute("MainPage", typeof(Pages.MainPage));
            Routing.RegisterRoute("HiraganaPage", typeof(zakladki.NewPage1));
            Routing.RegisterRoute("KatakanaPage", typeof(zakladki.NewPage2));
            Routing.RegisterRoute("HiraganaCharsPage", typeof(zakladki.HiraganaChars));
            Routing.RegisterRoute("KatakanaCharsPage", typeof(zakladki.KatakanaChars));
            Routing.RegisterRoute("ResultsPage", typeof(zakladki.AllUsersPage));
        }
    }
}
