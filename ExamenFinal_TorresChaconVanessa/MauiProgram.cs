using Microsoft.Extensions.Logging;
using ExamenFinalTorresChaconVanessa;
using ExamenFinalTorresChaconVanessa.Data;
using ExamenFinalTorresChaconVanessa.ViewModels;
using ExamenFinalTorresChaconVanessa.Views;
using Microsoft.Extensions.DependencyInjection;
namespace ExamenFinalTorresChaconVanessa
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "aeropuertos.db");

            builder.Services.AddHttpClient<AeropuertoService>(client =>
            {
                client.BaseAddress = new Uri("https://freetestapi.com/api/v1/");
            });

            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));

            builder.Services.AddSingleton<SearchViewModel>(s =>
                new SearchViewModel(
                    s.GetRequiredService<AeropuertoService>(),
                    s.GetRequiredService<DatabaseService>()
                ));

            builder.Services.AddSingleton<AeropuertoListViewModel>(s =>
                new AeropuertoListViewModel(
                    s.GetRequiredService<DatabaseService>()
                ));

            builder.Services.AddSingleton<SearchPage>();
            builder.Services.AddSingleton<ListPage>();

            builder.Services.AddSingleton<AppShell>();

            return builder.Build();
        }
    }

}
