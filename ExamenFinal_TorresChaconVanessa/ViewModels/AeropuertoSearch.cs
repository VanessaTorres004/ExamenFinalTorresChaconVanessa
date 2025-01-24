using System.Text.Json;
using System.Threading.Tasks;
using ExamenFinal_TorresChaconVanessa.Models;
using ExamenFinal_TorresChaconVanessa.Data;
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExamenFinal_TorresChaconVanessa.ViewModels
{
    [ObservableObject]
    public partial class SearchViewModel
    {
        private readonly AeropuertoService _aeropuertoService;
        private readonly DatabaseService _databaseService;

       
        public SearchViewModel() { }

      
        public SearchViewModel(AeropuertoService aeropuertoService, DatabaseService databaseService)
        {
            _aeropuertoService = aeropuertoService ?? throw new ArgumentNullException(nameof(aeropuertoService));
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
        }

       
        [ObservableProperty]
        private string searchText;

        
        [ObservableProperty]
        private string message;

       
        [RelayCommand]
        private async Task SearchAeropuerto()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Message = "Por favor, ingresa un nombre de país.";
                return;
            }

            try
            {
                
                var aeropuerto = await _aeropuertoService.SearchAeropuertoAsync(SearchText);
                if (aeropuerto != null)
                {
                    
                    await _databaseService.SaveAeropuertoAsync(aeropuerto);
                    Message = "Aeropuerto guardado exitosamente.";
                }
                else
                {
                    Message = "No se encontraron resultados.";
                }
            }
            catch (Exception ex)
            {
                Message = $"Error al buscar el aeropuerto: {ex.Message}";
            }
        }

        
        [RelayCommand]
        private void ClearSearch()
        {
            SearchText = string.Empty;
            Message = string.Empty;
        }
    }
}
