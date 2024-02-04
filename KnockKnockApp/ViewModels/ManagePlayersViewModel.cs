using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;
using KnockKnockApp.Views;

namespace KnockKnockApp.ViewModels
{
    public partial class ManagePlayersViewModel : ObservableObject
    {
        private readonly IManagePlayersService _managePlayersService;
        private readonly IServiceProvider _serviceProvider;

        public ManagePlayersViewModel(IManagePlayersService managePlayersService, IServiceProvider serviceProvider)
        {
            _managePlayersService = managePlayersService;
            _serviceProvider = serviceProvider;
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
            var selectGameModeView = _serviceProvider.GetService<SelectGameModeView>();
            _ = Application.Current.MainPage.Navigation.PushAsync(selectGameModeView);
        }
    }
}
