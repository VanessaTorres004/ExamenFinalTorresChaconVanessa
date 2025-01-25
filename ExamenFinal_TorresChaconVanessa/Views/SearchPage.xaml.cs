using ExamenFinalTorresChaconVanessa.Models;
using ExamenFinalTorresChaconVanessa.ViewModels;
using ExamenFinalTorresChaconVanessa.ViewModels;
namespace ExamenFinalTorresChaconVanessa.Views;


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
