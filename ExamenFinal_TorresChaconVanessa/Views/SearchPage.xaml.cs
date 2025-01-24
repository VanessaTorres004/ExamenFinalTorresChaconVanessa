using ExamenFinal_TorresChaconVanessa.V
namespace ExamenFinal_TorresChaconVanessa.Views;


public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}
    public SearchPage(SearchViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
}