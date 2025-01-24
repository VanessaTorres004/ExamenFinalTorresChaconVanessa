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
                
                var aeropuertosFromDb = await _databaseService.GetAeropuertoAsync();
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
