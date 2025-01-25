using ExamenFinalTorresChaconVanessa.Views;
namespace ExamenFinalTorresChaconVanessa
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
