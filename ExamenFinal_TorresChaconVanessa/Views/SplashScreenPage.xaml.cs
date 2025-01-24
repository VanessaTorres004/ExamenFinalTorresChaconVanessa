namespace ExamenFinal_TorresChaconVanessa.Views;

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

        
        Application.Current.MainPage = new AppShell();
    }
}
