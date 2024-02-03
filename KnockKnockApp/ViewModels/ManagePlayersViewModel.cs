using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;
using KnockKnockApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.ViewModels
{
    public partial class ManagePlayersViewModel : ObservableObject
    {
        private readonly GameplayView _gameplayView;
        private readonly IManagePlayersService _managePlayersService;

        public ManagePlayersViewModel(GameplayView gameplayView, IManagePlayersService managePlayersService)
        {
            _managePlayersService = managePlayersService;
            _gameplayView = gameplayView;
        }

        [ObservableProperty]
        public GeneralData generalDataInstance = GeneralData.Instance;

        [ObservableProperty]
        public string spielerNameEntryText = string.Empty;

        [RelayCommand]
        public void AddPlayer()
        {
            var playerName = SpielerNameEntryText;
            _managePlayersService.AddPlayer(playerName);
            SpielerNameEntryText = string.Empty;
        }

        [RelayCommand]
        public void RemovePlayer(object commandParameter)
        {
            var player = (Player)commandParameter;
            var playerId = player.Id;
            _managePlayersService.RemovePlayer(playerId);

        }

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            _ = Application.Current.MainPage.Navigation.PushAsync(_gameplayView);
        }
    }
}
