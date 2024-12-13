using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels.CardGameExtension
{
    [QueryProperty(nameof(CurrentExtension), "Extension")]
    public partial class ExtensionGameplayViewModel : ObservableObject
    {
        private readonly IExtensionCardManagementService _extensionCardManagementService;

        public ExtensionGameplayViewModel(ILocalizationService localizationService, IExtensionCardManagementService extensionCardManagementService)
        {
            LocalizationService = localizationService;
            _extensionCardManagementService = extensionCardManagementService;
            isGameRunning = true;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        private Extension? currentExtension;

        partial void OnCurrentExtensionChanged(Extension? value)
        {
            SetupExtensionAndDrawCard();
        }

        [ObservableProperty]
        private ExtensionCardDto? currentCard;

        [ObservableProperty]
        private bool isGameRunning;

        [RelayCommand]
        public async void DisplayNextCard()
        {
            var nextCard = await _extensionCardManagementService.DrawNextExtensionCardAsync();

            if (nextCard == null)
            {
                Shell.Current.GoToAsync("..", false);
            }

            CurrentCard = nextCard;
        }

        [RelayCommand]
        public async void NavigateToSelectCardGameExtension()
        {
            IsGameRunning = false;
            Shell.Current.GoToAsync("..", false);
        }

        public async void SetupExtensionAndDrawCard()
        {
            await _extensionCardManagementService.SetupAsync(CurrentExtension);
            CurrentCard = await _extensionCardManagementService.DrawNextExtensionCardAsync();
        }
    }
}
