using Microsoft.Maui.Controls;
using ExamenFinalTorresChaconVanessa.ViewModels;
       
namespace ExamenFinalTorresChaconVanessa.Views
{
    public partial class ListPage : ContentPage
    {
        private readonly AeropuertoListViewModel _viewModel;
        public ListPage(AeropuertoListViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;


            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            
            if (BindingContext is AeropuertoListViewModel viewModel)
            {
                if (viewModel.LoadAeropuertosCommand.CanExecute(null))
                {
                    await viewModel.LoadAeropuertosCommand.ExecuteAsync(null); 
                }
            }
        }
    }
}

	
