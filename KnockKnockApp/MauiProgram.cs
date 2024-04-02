using KnockKnockApp.Mapper;
using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using KnockKnockApp.ViewModels;
using KnockKnockApp.ViewModels.GameplayViewModels;
using KnockKnockApp.Views;
using KnockKnockApp.Views.GameplayViews;
using Microsoft.Extensions.Logging;

namespace KnockKnockApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            UpdateLocalDatabaseIfOutdated();

            // Services
            builder.Services.AddSingleton<IPlayerManagementService, PlayerManagementService>();
            builder.Services.AddSingleton<ITeamManagementService, TeamManagementService>();
            builder.Services.AddSingleton<IDeviceOrientationService, DeviceOrientationService>();
            builder.Services.AddSingleton<IGameModeRepository, GameModeRepository>();
            builder.Services.AddSingleton<IGameModeAndCardSetBindingRepository, GameModeAndCardSetBindingRepository>();
            builder.Services.AddTransient<ICardManagementService, CardManagementService>();

            builder.Services.AddSingleton<IGameCardMapper, GameCardMapper>();
            builder.Services.AddSingleton<IGameModeMapper, GameModeMapper>();
            builder.Services.AddSingleton<ICardSetRepository, CardSetRepository>();
            builder.Services.AddSingleton<IGameCardRepository, GameCardRepository>();
            // Helpers
            builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();
            // Views
            builder.Services.AddSingleton<ManagePlayers>();
            builder.Services.AddSingleton<SelectGameModeView>();
            builder.Services.AddTransient<BasicGameplayView>();
            builder.Services.AddTransient<GameModeSettingsView>();
            // ViewModels
            builder.Services.AddSingleton<ManagePlayersViewModel>();
            builder.Services.AddSingleton<SelectGameModeViewModel>();
            builder.Services.AddTransient<BasicGameplayViewModel>();
            builder.Services.AddTransient<GameModeSettingsViewModel>();

            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void UpdateLocalDatabaseIfOutdated()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");

            var lastWriteTimeAppDataDir = File.GetLastWriteTime(FileSystem.Current.AppDataDirectory);
            var lastWriteTimeLocalDb = File.GetLastWriteTime(dbPath);

            if (lastWriteTimeAppDataDir > lastWriteTimeLocalDb)
            {
                using var databaseFileStream = FileSystem.OpenAppPackageFileAsync("database.sqlite").Result;

                using (MemoryStream databaseMemoryStream = new MemoryStream())
                {
                    databaseFileStream.CopyTo(databaseMemoryStream);
                    File.WriteAllBytes(dbPath, databaseMemoryStream.ToArray());
                }
            }
        }
    }
}
