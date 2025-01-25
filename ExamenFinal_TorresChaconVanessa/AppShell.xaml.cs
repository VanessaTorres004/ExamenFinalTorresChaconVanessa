using ExamenFinalTorresChaconVanessa.Views;
namespace ExamenFinalTorresChaconVanessa
{
    public partial class AppShell : Shell
    {
        public AppShell(SearchPage searchPage)
        {
            InitializeComponent();


            Items.Add(new ShellContent
            {
                Title = "Buscar",
                Content = searchPage
            });
        }

    }
}



