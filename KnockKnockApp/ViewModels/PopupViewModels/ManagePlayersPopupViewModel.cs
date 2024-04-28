using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.ViewModels.PopupViewModels
{
    public partial class ManagePlayersPopupViewModel : ObservableObject
    {
        private readonly IPlayerManagementService _playerManagementService;

        public ManagePlayersPopupViewModel(ILocalizationService localizationService, IPlayerManagementService playerManagementService)
        {
            LocalizationService = localizationService;
            _playerManagementService = playerManagementService;

            AllPlayers = _playerManagementService.GetAllPlayers();
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        public ObservableCollection<Player> allPlayers;

        [ObservableProperty]
        public string spielerNameEntryText = string.Empty;

        [RelayCommand]
        public void AddPlayer()
        {
            var playerName = SpielerNameEntryText;
            _playerManagementService.AddPlayer(playerName);
            SpielerNameEntryText = string.Empty;
        }

        [RelayCommand]
        public void RemovePlayer(object commandParameter)
        {
            var player = (Player)commandParameter;
            var playerId = player.Id;
            _playerManagementService.RemovePlayer(playerId);
        }
    }
}
