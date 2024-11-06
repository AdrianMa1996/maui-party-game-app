using KnockKnockApp.Views;
using KnockKnockApp.Views.CardGameExtension;
using KnockKnockApp.Views.GameplayViews;

namespace KnockKnockApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute($"{nameof(SelectGameModeView)}", typeof(SelectGameModeView));
            Routing.RegisterRoute($"{nameof(SelectCardGameExtensionView)}", typeof(SelectCardGameExtensionView));
            Routing.RegisterRoute($"{nameof(LanguageSettingsView)}", typeof(LanguageSettingsView));
            Routing.RegisterRoute($"{nameof(PurchasePrimeView)}", typeof(PurchasePrimeView));
            Routing.RegisterRoute($"{nameof(TermsOfUseView)}", typeof(TermsOfUseView));
            Routing.RegisterRoute($"{nameof(PrivacyPolicyView)}", typeof(PrivacyPolicyView));
            Routing.RegisterRoute($"{nameof(SelectGameModeView)}/{nameof(BasicGameplayView)}", typeof(BasicGameplayView));
            Routing.RegisterRoute($"{nameof(SelectCardGameExtensionView)}/{nameof(ExtensionGameplayView)}", typeof(ExtensionGameplayView));
            Routing.RegisterRoute($"{nameof(SelectGameModeView)}/{nameof(LoadingBasicGameplayView)}", typeof(LoadingBasicGameplayView));
            Routing.RegisterRoute("SelectGameModeView/GameModeSettingsView", typeof(GameModeSettingsView));
        }
    }
}
