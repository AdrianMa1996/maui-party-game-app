using KnockKnockApp.Views;
using KnockKnockApp.Views.GameplayViews;

namespace KnockKnockApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute($"{nameof(SelectGameModeView)}", typeof(SelectGameModeView));
            Routing.RegisterRoute($"{nameof(SelectGameModeView)}/{nameof(BasicGameplayView)}", typeof(BasicGameplayView));
            Routing.RegisterRoute($"{nameof(SelectGameModeView)}/{nameof(LoadingBasicGameplayView)}", typeof(LoadingBasicGameplayView));
            Routing.RegisterRoute("SelectGameModeView/GameModeSettingsView", typeof(GameModeSettingsView));
        }
    }
}
