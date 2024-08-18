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

    private int remainingAttempts;

    private bool startNewAttempt;

    private bool isGameOver;

    private Color grayLedColor = new Color((float)0.675, (float)0.675, (float)0.675);
    private Color greenLedColor = new Color((float)0, (float)0.502, (float)0);
    private Color redLedColor = new Color((float)1, (float)0, (float)0);

    private void Higher_Button_Clicked(object sender, EventArgs e)
    {
        var nextPokerCard = GetNextPokerCard();
        if (nextPokerCard.CardValue > currentPokerCard.CardValue)
        {
            remainingAttempts = remainingAttempts - 1;
        }
        else
        {
            startNewAttempt = true;
        }

        currentPokerCard = nextPokerCard;
        RefreshPunishmentGameView();
    }

    private void Same_Button_Clicked(object sender, EventArgs e)
    {
        var nextPokerCard = GetNextPokerCard();
        if (nextPokerCard.CardValue == currentPokerCard.CardValue)
        {
            remainingAttempts = remainingAttempts - 1;
        }
        else
        {
            startNewAttempt = true;
        }

        currentPokerCard = nextPokerCard;
        RefreshPunishmentGameView();
    }

    private void Deeper_Button_Clicked(object sender, EventArgs e)
    {
        var nextPokerCard = GetNextPokerCard();
        if (nextPokerCard.CardValue < currentPokerCard.CardValue)
        {
            remainingAttempts = remainingAttempts - 1;
        }
        else
        {
            startNewAttempt = true;
        }

        currentPokerCard = nextPokerCard;
        RefreshPunishmentGameView();
    }

    private void RestartPunishmentGame_Button_Clicked(object sender, EventArgs e)
    {
        SetupNewPunishmentGame();
    }

    private PokerCard GetNextPokerCard()
    {
        var nextPokerCard = pokerCardDeck[new Random().Next(pokerCardDeck.Count)];
        pokerCardDeck.Remove(nextPokerCard);
        return nextPokerCard;
    }

    private void RefreshPunishmentGameView()
    {
        switch (remainingAttempts)
        {
            case 5:
                LedOne.BackgroundColor = grayLedColor;
                LedTwo.BackgroundColor = grayLedColor;
                LedThree.BackgroundColor = grayLedColor;
                LedFour.BackgroundColor = grayLedColor;
                LedFive.BackgroundColor = grayLedColor;
                break;
            case 4:
                LedOne.BackgroundColor = greenLedColor;
                LedTwo.BackgroundColor = grayLedColor;
                LedThree.BackgroundColor = grayLedColor;
                LedFour.BackgroundColor = grayLedColor;
                LedFive.BackgroundColor = grayLedColor;
                break;
            case 3:
                LedOne.BackgroundColor = greenLedColor;
                LedTwo.BackgroundColor = greenLedColor;
                LedThree.BackgroundColor = grayLedColor;
                LedFour.BackgroundColor = grayLedColor;
                LedFive.BackgroundColor = grayLedColor;
                break;
            case 2:
                LedOne.BackgroundColor = greenLedColor;
                LedTwo.BackgroundColor = greenLedColor;
                LedThree.BackgroundColor = greenLedColor;
                LedFour.BackgroundColor = grayLedColor;
                LedFive.BackgroundColor = grayLedColor;
                break;
            case 1:
                LedOne.BackgroundColor = greenLedColor;
                LedTwo.BackgroundColor = greenLedColor;
                LedThree.BackgroundColor = greenLedColor;
                LedFour.BackgroundColor = greenLedColor;
                LedFive.BackgroundColor = grayLedColor;
                break;
            case 0:
                LedOne.BackgroundColor = greenLedColor;
                LedTwo.BackgroundColor = greenLedColor;
                LedThree.BackgroundColor = greenLedColor;
                LedFour.BackgroundColor = greenLedColor;
                LedFive.BackgroundColor = greenLedColor;
                isGameOver = true;
                break;

        }

        if (startNewAttempt)
        {
            LedOne.BackgroundColor = redLedColor;
            LedTwo.BackgroundColor = redLedColor;
            LedThree.BackgroundColor = redLedColor;
            LedFour.BackgroundColor = redLedColor;
            LedFive.BackgroundColor = redLedColor;
        }

        CurrentPokerCard.Source = currentPokerCard.CardImage;

        GameOverview.IsVisible = !isGameOver && !startNewAttempt;
        OverviewNumberOfKnockers.Text = (6 - remainingAttempts).ToString();
        RemainingAttempts.Text = remainingAttempts.ToString();

        RestartPunishmentGameText.IsVisible = startNewAttempt;
        RestartNumberOfKnockers.Text = (6 - remainingAttempts).ToString();

        EndPunishmentGameText.IsVisible= isGameOver && !startNewAttempt;

        HigherButton.IsVisible = !isGameOver && !startNewAttempt;
        SameButton.IsVisible = !isGameOver && !startNewAttempt;
        DeeperButton.IsVisible = !isGameOver && !startNewAttempt;
        RestartPunishmentGameButton.IsVisible = startNewAttempt;
        EndPunishmentGameButton.IsVisible = isGameOver && !startNewAttempt;
        return;
    }

    private void SetupNewPunishmentGame()
    {
        pokerCardDeck = new List<PokerCard>()
        {
            new PokerCard(1, "clubs_two.png"),
            new PokerCard(2, "clubs_three.png"),
            new PokerCard(3, "clubs_four.png"),
            new PokerCard(4, "clubs_five.png"),
            new PokerCard(5, "clubs_six.png"),
            new PokerCard(6, "clubs_seven.png"),
            new PokerCard(7, "clubs_eight.png"),
            new PokerCard(8, "clubs_nine.png"),
            new PokerCard(9, "clubs_ten.png"),
            new PokerCard(10, "clubs_jack.png"),
            new PokerCard(11, "clubs_queen.png"),
            new PokerCard(12, "clubs_king.png"),
            new PokerCard(13, "clubs_ass.png"),
            new PokerCard(1, "diamonds_two.png"),
            new PokerCard(2, "diamonds_three.png"),
            new PokerCard(3, "diamonds_four.png"),
            new PokerCard(4, "diamonds_five.png"),
            new PokerCard(5, "diamonds_six.png"),
            new PokerCard(6, "diamonds_seven.png"),
            new PokerCard(7, "diamonds_eight.png"),
            new PokerCard(8, "diamonds_nine.png"),
            new PokerCard(9, "diamonds_ten.png"),
            new PokerCard(10, "diamonds_jack.png"),
            new PokerCard(11, "diamonds_queen.png"),
            new PokerCard(12, "diamonds_king.png"),
            new PokerCard(13, "diamonds_ass.png"),
            new PokerCard(1, "hearts_two.png"),
            new PokerCard(2, "hearts_three.png"),
            new PokerCard(3, "hearts_four.png"),
            new PokerCard(4, "hearts_five.png"),
            new PokerCard(5, "hearts_six.png"),
            new PokerCard(6, "hearts_seven.png"),
            new PokerCard(7, "hearts_eight.png"),
            new PokerCard(8, "hearts_nine.png"),
            new PokerCard(9, "hearts_ten.png"),
            new PokerCard(10, "hearts_jack.png"),
            new PokerCard(11, "hearts_queen.png"),
            new PokerCard(12, "hearts_queen.png"),
            new PokerCard(13, "hearts_king.png"),
            new PokerCard(1, "spades_two.png"),
            new PokerCard(2, "spades_three.png"),
            new PokerCard(3, "spades_four.png"),
            new PokerCard(4, "spades_five.png"),
            new PokerCard(5, "spades_six.png"),
            new PokerCard(6, "spades_seven.png"),
            new PokerCard(7, "spades_eight.png"),
            new PokerCard(8, "spades_nine.png"),
            new PokerCard(9, "spades_ten.png"),
            new PokerCard(10, "spades_jack.png"),
            new PokerCard(11, "spades_queen.png"),
            new PokerCard(12, "spades_king.png"),
            new PokerCard(13, "spades_ass.png")
        };

        isGameOver = false;
        startNewAttempt = false;
        remainingAttempts = 5;

        currentPokerCard = GetNextPokerCard();
        RefreshPunishmentGameView();
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