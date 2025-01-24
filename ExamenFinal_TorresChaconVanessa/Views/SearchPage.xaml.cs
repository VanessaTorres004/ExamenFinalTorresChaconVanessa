using ExamenFinal_TorresChaconVanessa.ViewModels;
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
