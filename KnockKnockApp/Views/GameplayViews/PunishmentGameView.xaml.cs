using CommunityToolkit.Mvvm.Input;

namespace KnockKnockApp.Views.GameplayViews;

public partial class PunishmentGameView : ContentView
{
    public static readonly BindableProperty LeaveGameModeCommandProperty = BindableProperty.Create(nameof(LeaveGameModeCommand), typeof(RelayCommand), typeof(PunishmentGameView));

    public RelayCommand LeaveGameModeCommand
    {
        get { return (RelayCommand)GetValue(LeaveGameModeCommandProperty); }
        set { SetValue(LeaveGameModeCommandProperty, value); }
    }

    public static readonly BindableProperty EndPunishmentGameCommandProperty = BindableProperty.Create(nameof(EndPunishmentGameCommand), typeof(RelayCommand), typeof(PunishmentGameView));

    public RelayCommand EndPunishmentGameCommand
    {
        get { return (RelayCommand)GetValue(EndPunishmentGameCommandProperty); }
        set { SetValue(EndPunishmentGameCommandProperty, value); }
    }

    public PunishmentGameView()
	{
        InitializeComponent();
        SetupNewPunishmentGame();
    }

    private PokerCard currentPokerCard;

    private List<PokerCard> pokerCardDeck;

    private bool isGameOver;

    private void Higher_Button_Clicked(object sender, EventArgs e)
    {
        return;
    }

    private void Same_Button_Clicked(object sender, EventArgs e)
    {
        return;
    }

    private void Deeper_Button_Clicked(object sender, EventArgs e)
    {
        return;
    }

    private void RestartPunishmentGame_Button_Clicked(object sender, EventArgs e)
    {
        return;
    }

    private void ShowNextPokerCard()
    {
        currentPokerCard = pokerCardDeck[0]; // gib eine zufällige PokerKarte zurück und entferne sie aus dem pokerCardDeck
        RefreshPunishmentGameView();
        return;
    }

    private void RefreshPunishmentGameView()
    {
        CurrentPokerCard.Source = currentPokerCard.CardImage;

        HigherButton.IsVisible = !isGameOver;
        SameButton.IsVisible = !isGameOver;
        DeeperButton.IsVisible = !isGameOver;
        RestartPunishmentGameButton.IsVisible = isGameOver;
        EndPunishmentGameButton.IsVisible = isGameOver;
        return;
    }

    private void SetupNewPunishmentGame()
    {
        pokerCardDeck = new List<PokerCard>()
        {
            new PokerCard(1, "dotnet_bot.svg"),
            new PokerCard(1, "dotnet_bot.svg"),
            new PokerCard(1, "dotnet_bot.svg"),
            new PokerCard(1, "dotnet_bot.svg"),
            new PokerCard(2, "dotnet_bot.svg"),
            new PokerCard(2, "dotnet_bot.svg"),
            new PokerCard(2, "dotnet_bot.svg"),
            new PokerCard(2, "dotnet_bot.svg")
        };

        isGameOver = false;
        ShowNextPokerCard();
    }
}

public class PokerCard
{
    public PokerCard(int cardValue, string cardImage)
    {
        CardValue = cardValue;
        CardImage = cardImage;
    }

    public int CardValue { get; set; }
    public string CardImage { get; set; }
}