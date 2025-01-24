using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenFinal_TorresChaconVanessa.Data;
using ExamenFinal_TorresChaconVanessa.Models;

namespace ExamenFinal_TorresChaconVanessa.ViewModels
{
    public partial class AeropuertoListViewModel : ObservableObject
    {
        private readonly AeropuertoService _databaseService;

        [ObservableProperty]
        private ObservableCollection<Aeropuerto> aeropuertos;

        public AeropuertoListViewModel() { }

        public AeropuertoListViewModel(AeropuertoService databaseService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            Aeropuerto = new ObservableCollection<Aeropuerto>();
        }

        [RelayCommand]
        private async Task LoadAeropuertosAsync()
        {
            try
            {
                
                var aeropuertosFromDb = await _databaseService.GetAeropuertosAsync();
                if (aeropuertosFromDb != null && aeropuertosFromDb.Any())
                {
                    Aeropuertos.Clear();
                    foreach (var aeropuerto in aeropuertosFromDb)
                    {
                        Aeropuertos.Add(aeropuerto);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron aeropuertos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los aeropuertos: {ex.Message}");
            }
        }
    }
}
