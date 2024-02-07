using KnockKnockApp.Views;
using KnockKnockApp.Views.GameplayViews;

namespace KnockKnockApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SelectGameModeView", typeof(SelectGameModeView));
            Routing.RegisterRoute("SelectGameModeView/BasicGameplayView", typeof(BasicGameplayView));
            Routing.RegisterRoute("SelectGameModeView/GameModeSettingsView", typeof(GameModeSettingsView));
        }
    }
}
