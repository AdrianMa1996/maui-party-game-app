using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using KnockKnockApp.ViewModels;
using KnockKnockApp.Views;
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
            // Views
            builder.Services.AddSingleton<ManagePlayers>();
            builder.Services.AddSingleton<GameplayView>();
            builder.Services.AddSingleton<SelectGameModeView>();
            builder.Services.AddSingleton<GameCardView>();
            // ViewModels
            builder.Services.AddSingleton<ManagePlayersViewModel>();
            builder.Services.AddSingleton<GameplayViewModel>();

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
