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
            // Services
            builder.Services.AddTransient<ITemporaryDataRepository, TemporaryDataRepository>();
            builder.Services.AddTransient<IManagePlayersService, ManagePlayersService>();
            builder.Services.AddTransient<IDeviceOrientationService, DeviceOrientationService>();
            // Helpers
            builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();
            // Views
            builder.Services.AddTransient<ManagePlayers>();
            builder.Services.AddTransient<SelectGameModeView>();
            builder.Services.AddTransient<BasicGameplayView>();
            // ViewModels
            builder.Services.AddTransient<ManagePlayersViewModel>();
            builder.Services.AddTransient<SelectGameModeViewModel>();
            builder.Services.AddTransient<BasicGameplayViewModel>();

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
    }
}
