using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels.CardGameExtension
{
    public partial class SelectCardGameExtensionViewModel : ObservableObject
    {
        private readonly IExtensionRepository _extensionRepository;

        public SelectCardGameExtensionViewModel(ILocalizationService localizationService, IExtensionRepository extensionRepository)
        {
            LocalizationService = localizationService;
            _extensionRepository = extensionRepository;

            RefreshExtensionCollection();
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        public ObservableCollection<Extension> extensionCollection = new ObservableCollection<Extension>();

        [RelayCommand]
        public async void RefreshExtensionCollection()
        {
            ExtensionCollection = new ObservableCollection<Extension>(await _extensionRepository.GetExtensionsAsync());
        }

        [RelayCommand]
        public void NavigateToExtensionGameplay(Extension extension)
        {
            var navParam = new Dictionary<string, object>
            {
                { "Extension", extension }
            };
            AppShell.Current.GoToAsync("ExtensionGameplayView", false, navParam);
        }

        [RelayCommand]
        public void NavigateToSelectGameModeView()
        {
            Shell.Current.GoToAsync("..", false);
        }
    }
}
