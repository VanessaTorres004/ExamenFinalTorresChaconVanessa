using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenFinalTorresChaconVanessa.Data;
using ExamenFinalTorresChaconVanessa.Models;

namespace ExamenFinalTorresChaconVanessa.ViewModels
{
    public partial class AeropuertoListViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        [ObservableProperty]

        private ObservableCollection<Aeropuerto> aeropuertos;

        public AeropuertoListViewModel() { }

        public AeropuertoListViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            aeropuertos = new ObservableCollection<Aeropuerto>();
        }

        [RelayCommand]
        private async Task LoadAeropuertosAsync()
        {
            try
            {
                
                var aeropuertosFromDb = await _databaseService.GetAeropuertosAsync();
                if (aeropuertosFromDb != null && aeropuertosFromDb.Any())
                {
                    aeropuertos.Clear();
                    foreach (var aeropuerto in aeropuertosFromDb)
                    {
                        aeropuertos.Add(aeropuerto);
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
