using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExamenFinalTorresChaconVanessa.Models;
using ExamenFinalTorresChaconVanessa.Data;
using System.IO;
using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using System.Linq;
using Microsoft.Maui.Controls;

namespace ExamenFinalTorresChaconVanessa.ViewModels
{
    [ObservableObject]
    public partial class SearchViewModel
    {
        private readonly AeropuertoService _aeropuertoService;
        private readonly DatabaseService _databaseService;

       
        public SearchViewModel() 
        {
            Aeropuertos = new ObservableCollection<Aeropuerto>();

        }

      
        public SearchViewModel(AeropuertoService aeropuertoService, DatabaseService databaseService)
        {
            _aeropuertoService = aeropuertoService ?? throw new ArgumentNullException(nameof(aeropuertoService));
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            Aeropuertos = new ObservableCollection<Aeropuerto>();
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
