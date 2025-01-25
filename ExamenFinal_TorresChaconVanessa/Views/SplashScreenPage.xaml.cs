using ExamenFinalTorresChaconVanessa.Views;

namespace ExamenFinalTorresChaconVanessa.Views;

public partial class SplashScreenPage : ContentPage
{
    public SplashScreenPage()
    {
        InitializeComponent();
        StartLoading();
    }
            
 
        private async void StartLoading()
        {
            
            await Task.Delay(3000);

            
            var searchPage = new SearchPage();
            Application.Current.MainPage = new AppShell(searchPage);
        }
    }


