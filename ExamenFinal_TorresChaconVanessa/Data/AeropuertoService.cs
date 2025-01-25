using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExamenFinalTorresChaconVanessa.Models;

namespace ExamenFinalTorresChaconVanessa.Data
{
    public class AeropuertoService
    {
        private readonly HttpClient _httpClient;

        public AeropuertoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Aeropuerto> SearchAeropuertoAsync(string query)
        {
            try
            {
                
                string url = $"https://freetestapi.com/api/v1/airports?search={query}&limit=1";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error en la API: {response.StatusCode}");
                    return null;
                }

                
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta JSON: {jsonResponse}");

               
                var aeropuertoResponses = JsonSerializer.Deserialize<List<AeropuertoResponse>>(jsonResponse);

                
                if (aeropuertoResponses == null || aeropuertoResponses.Count == 0)
                {
                    Console.WriteLine("No se encontraron aeropuertos.");
                    return null;
                }
                var aeropuertoResponse = aeropuertoResponses[0];

                
                return new Aeropuerto
                {
                    Name = aeropuertoResponse.airportName,
                    Country = aeropuertoResponse.country,
                    Latitude = aeropuertoResponse.latitud,
                    Longitude = aeropuertoResponse.longitud,
                    Email = aeropuertoResponse.email,
                  
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SearchAeropuertoAsync: {ex.Message}");
                return null;
            }
        }
    }

   
    public class AeropuertoResponse
    {
        public string airportName { get; set; }
        public string country { get; set; }   
        public double latitud { get; set; } 
        public double longitud { get; set; } 
        public string email { get; set; }    
    }
}

