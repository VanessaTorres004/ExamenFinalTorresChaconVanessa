using ExamenFinalTorresChaconVanessa.Views;
namespace ExamenFinalTorresChaconVanessa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashScreenPage();

            var searchPage = new SearchPage();
            LoadAppShellAsync(searchPage);
        }

        private async void LoadAppShellAsync(SearchPage searchPage)
        {
            await Task.Delay(3000);
            MainPage = new AppShell(searchPage);
        }
    }
}
