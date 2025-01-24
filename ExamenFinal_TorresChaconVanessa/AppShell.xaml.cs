using ExamenFinal_TorresChaconVanessa.Views;
namespace ExamenFinal_TorresChaconVanessa


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



