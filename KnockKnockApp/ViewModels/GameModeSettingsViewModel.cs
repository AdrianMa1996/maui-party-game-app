using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Repositories;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    [QueryProperty(nameof(CurrentGameMode), "GameMode")]
    public partial class GameModeSettingsViewModel : ObservableObject
    {
        private readonly IGameModeAndCardSetBindingRepository _gameModeAndCardSetBindingRepository;

        public GameModeSettingsViewModel(IGameModeAndCardSetBindingRepository gameModeAndCardSetBindingRepository) 
        {
            _gameModeAndCardSetBindingRepository = gameModeAndCardSetBindingRepository;
        }

        [ObservableProperty]
        private GameMode? currentGameMode;

        partial void OnCurrentGameModeChanged(GameMode? value)
        {
            RefreshGameModeAndCardSetBindingCollection();
        }

        [ObservableProperty]
        public ObservableCollection<GameModeAndCardSetBinding>? gameModeAndCardSetBindingCollection;

        [RelayCommand]
        public async void RefreshGameModeAndCardSetBindingCollection()
        {
            var gameModeAndCardSetBindingList = await _gameModeAndCardSetBindingRepository.GetGameModeAndCardSetBindingsByGameModeIdAsync(CurrentGameMode.GameModeID);
            GameModeAndCardSetBindingCollection = new ObservableCollection<GameModeAndCardSetBinding>(gameModeAndCardSetBindingList);
        }

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            _gameModeAndCardSetBindingRepository.UpdateGameModeAndCardSetBindingsAsync(GameModeAndCardSetBindingCollection.ToList());
            Shell.Current.GoToAsync("..", true);
        }
    }
}
