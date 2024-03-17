using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KnockKnockApp.Views.GameplayViews;

public partial class ManageTeamsView : ContentView
{
    public static readonly BindableProperty AllPlayersProperty = BindableProperty.Create(nameof(AllPlayers), typeof(ObservableCollection<Player>), typeof(ManageTeamsView));

    public ObservableCollection<Player> AllPlayers
    {
        get => (ObservableCollection<Player>)GetValue(AllPlayersProperty);
        set => SetValue(AllPlayersProperty, value);
    }

    public ManageTeamsView()
	{
		InitializeComponent();
	}
}