using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Views.GameplayViews;

public partial class ManageTeamsView : ContentView
{
    public static readonly BindableProperty AllPlayersProperty = BindableProperty.Create(nameof(AllPlayers), typeof(ObservableCollection<Player>), typeof(ManageTeamsView));

    public ObservableCollection<Player> AllPlayers
    {
        get => (ObservableCollection<Player>)GetValue(AllPlayersProperty);
        set => SetValue(AllPlayersProperty, value);
    }

    public static readonly BindableProperty TeamlessPlayersProperty = BindableProperty.Create(nameof(TeamlessPlayers), typeof(ObservableCollection<Player>), typeof(ManageTeamsView));

    public ObservableCollection<Player> TeamlessPlayers
    {
        get => (ObservableCollection<Player>)GetValue(TeamlessPlayersProperty);
        set => SetValue(TeamlessPlayersProperty, value);
    }

    public static readonly BindableProperty TeamOnePlayersProperty = BindableProperty.Create(nameof(TeamOnePlayers), typeof(ObservableCollection<Player>), typeof(ManageTeamsView));

    public ObservableCollection<Player> TeamOnePlayers
    {
        get => (ObservableCollection<Player>)GetValue(TeamOnePlayersProperty);
        set => SetValue(TeamOnePlayersProperty, value);
    }

    public static readonly BindableProperty TeamTwoPlayersProperty = BindableProperty.Create(nameof(TeamTwoPlayers), typeof(ObservableCollection<Player>), typeof(ManageTeamsView));

    public ObservableCollection<Player> TeamTwoPlayers
    {
        get => (ObservableCollection<Player>)GetValue(TeamTwoPlayersProperty);
        set => SetValue(TeamTwoPlayersProperty, value);
    }

    public static readonly BindableProperty StartGameCommandProperty = BindableProperty.Create(nameof(StartGameCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand StartGameCommand
    {
        get => (RelayCommand)GetValue(StartGameCommandProperty);
        set => SetValue(StartGameCommandProperty, value);
    }

    public static readonly BindableProperty AddPlayerToTeamOneCommandProperty = BindableProperty.Create(nameof(AddPlayerToTeamOneCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand AddPlayerToTeamOneCommand
    {
        get => (RelayCommand)GetValue(AddPlayerToTeamOneCommandProperty);
        set => SetValue(AddPlayerToTeamOneCommandProperty, value);
    }

    public static readonly BindableProperty AddPlayerToTeamTwoCommandProperty = BindableProperty.Create(nameof(AddPlayerToTeamTwoCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand AddPlayerToTeamTwoCommand
    {
        get => (RelayCommand)GetValue(AddPlayerToTeamTwoCommandProperty);
        set => SetValue(AddPlayerToTeamTwoCommandProperty, value);
    }

    public static readonly BindableProperty RemovePlayerOfTeamOneCommandProperty = BindableProperty.Create(nameof(RemovePlayerOfTeamOneCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand RemovePlayerOfTeamOneCommand
    {
        get => (RelayCommand)GetValue(RemovePlayerOfTeamOneCommandProperty);
        set => SetValue(RemovePlayerOfTeamOneCommandProperty, value);
    }

    public static readonly BindableProperty RemovePlayerOfTeamTwoCommandProperty = BindableProperty.Create(nameof(RemovePlayerOfTeamTwoCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand RemovePlayerOfTeamTwoCommand
    {
        get => (RelayCommand)GetValue(RemovePlayerOfTeamTwoCommandProperty);
        set => SetValue(RemovePlayerOfTeamTwoCommandProperty, value);
    }

    public ManageTeamsView()
	{
		InitializeComponent();
	}
}