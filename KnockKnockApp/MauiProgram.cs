using CommunityToolkit.Maui;
using KnockKnockApp.Mapper;
using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using KnockKnockApp.ViewModels;
using KnockKnockApp.ViewModels.CardGameExtension;
using KnockKnockApp.ViewModels.GameplayViewModels;
using KnockKnockApp.Views;
using KnockKnockApp.Views.CardGameExtension;
using KnockKnockApp.Views.GameplayViews;
using Microsoft.Extensions.Logging;
using SQLite;
using KnockKnockApp.Models.Database;

namespace KnockKnockApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            builder.UseMauiCommunityToolkit();

            UpdateLocalDatabaseIfOutdated();

            // Services
            builder.Services.AddSingleton<IPlayerManagementService, PlayerManagementService>();
            builder.Services.AddSingleton<ITeamManagementService, TeamManagementService>();
            builder.Services.AddSingleton<ICardTextPlaceholderService, CardTextPlaceholderService>();
            builder.Services.AddSingleton<IDeviceOrientationService, DeviceOrientationService>();
            builder.Services.AddSingleton<ISubscriptionManagementService, SubscriptionManagementService>();
            builder.Services.AddSingleton<IGameModeRepository, GameModeRepository>();
            builder.Services.AddSingleton<IExtensionRepository, ExtensionRepository>();
            builder.Services.AddSingleton<IGameModeAndCardSetBindingRepository, GameModeAndCardSetBindingRepository>();
            builder.Services.AddTransient<ICardManagementService, CardManagementService>();
            builder.Services.AddTransient<IExtensionCardManagementService, ExtensionCardManagementService>();
            builder.Services.AddSingleton<ILocalizationService, LocalizationService>();

            builder.Services.AddSingleton<IGameCardMapper, GameCardMapper>();
            builder.Services.AddSingleton<IGameModeMapper, GameModeMapper>();
            builder.Services.AddSingleton<ICardSetRepository, CardSetRepository>();
            builder.Services.AddSingleton<IGameCardRepository, GameCardRepository>();

            builder.Services.AddSingleton<IExtensionCardMapper, ExtensionCardMapper>();
            builder.Services.AddSingleton<IExtensionMapper, ExtensionMapper>();
            builder.Services.AddSingleton<IExtensionAndExtensionCardSetBindingRepository, ExtensionAndExtensionCardSetBindingRepository>();
            builder.Services.AddSingleton<IExtensionCardRepository, ExtensionCardRepository>();
            builder.Services.AddSingleton<IExtensionCardSetRepository, ExtensionCardSetRepository>();
            // Helpers
            builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();
            // Views
            builder.Services.AddSingleton<WelcomePageView>();
            builder.Services.AddSingleton<ManagePlayers>();
            builder.Services.AddTransient<SelectGameModeView>();
            builder.Services.AddTransient<SelectCardGameExtensionView>();
            builder.Services.AddTransient<LoadingBasicGameplayView>();
            builder.Services.AddTransient<BasicGameplayView>();
            builder.Services.AddTransient<ExtensionGameplayView>();
            builder.Services.AddTransient<GameModeSettingsView>();
            builder.Services.AddTransient<PurchasePrimeView>();
            builder.Services.AddTransient<TermsOfUseView>();
            builder.Services.AddTransient<PrivacyPolicyView>();
            builder.Services.AddTransient<LanguageSettingsView>();
            // ViewModels
            builder.Services.AddSingleton<WelcomePageViewModel>();
            builder.Services.AddSingleton<ManagePlayersViewModel>();
            builder.Services.AddTransient<SelectGameModeViewModel>();
            builder.Services.AddTransient<SelectCardGameExtensionViewModel>();
            builder.Services.AddTransient<BasicGameplayViewModel>();
            builder.Services.AddTransient<ExtensionGameplayViewModel>();
            builder.Services.AddTransient<GameModeSettingsViewModel>();
            builder.Services.AddTransient<PurchasePrimeViewModel>();
            builder.Services.AddTransient<TermsOfUseViewModel>();
            builder.Services.AddTransient<PrivacyPolicyViewModel>();
            builder.Services.AddTransient<LanguageSettingsViewModel>();

            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("Calibri.ttf", "Calibri");
                fonts.AddFont("BowlbyOneSC-Regular.ttf", "BowlbyOneSC");
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

            var ConnectedAppBuildOfDatabase = GetWithDatabaseConnectedAppBuildString();

            if (lastWriteTimeAppDataDir > lastWriteTimeLocalDb || ConnectedAppBuildOfDatabase != AppInfo.Current.BuildString)
            {
                using var databaseFileStream = FileSystem.OpenAppPackageFileAsync("database.sqlite").Result;

                using (MemoryStream databaseMemoryStream = new MemoryStream())
                {
                    databaseFileStream.CopyTo(databaseMemoryStream);
                    File.WriteAllBytes(dbPath, databaseMemoryStream.ToArray());
                }

                try
                {
                    using (var dbConnection = new SQLiteConnection(dbPath))
                    {
                        var databaseInfo = dbConnection.Find<DatabaseInfo>(1);
                        databaseInfo.ConnectedAppBuild = AppInfo.Current.BuildString;
                        dbConnection.Update(databaseInfo);
                    }
                }
                catch
                {
                    // do nothing
                }
            }
        }

        private static string GetWithDatabaseConnectedAppBuildString()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");

                using (var dbConnection = new SQLiteConnection(dbPath))
                {
                    var databaseInfo = dbConnection.Find<DatabaseInfo>(1);
                    return databaseInfo.ConnectedAppBuild;
                }
            }
            catch 
            { 
                return string.Empty;
            }
        }
    }
}
