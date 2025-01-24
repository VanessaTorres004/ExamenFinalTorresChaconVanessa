using ExamenFinal_TorresChaconVanessa.Views;
namespace ExamenFinal_TorresChaconVanessa
{
    public partial class App : Application
    {
        public App(SearchPage searchPage)
        {
            InitializeComponent();

            MainPage = new AppShell(searchPage);
        }
    }
}
