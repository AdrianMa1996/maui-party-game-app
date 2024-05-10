using KnockKnockApp.Models.Database;
using System.Globalization;

namespace KnockKnockApp.Converters
{
    public class CardSetCategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CardSetCategory)
            {
                CardSetCategory category = (CardSetCategory)value;
                Color color;

                switch (category)
                {
                    case CardSetCategory.Information:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.Basic:
                        color = GetColorFromResources("PurpleCardColor");
                        break;
                    case CardSetCategory.Game:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.Dare:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.Duel:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.Rule:
                        color = GetColorFromResources("RedCardColor");
                        break;
                    case CardSetCategory.Curse:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.Powerup:
                        color = GetColorFromResources("OrangeCardColor");
                        break;
                    case CardSetCategory.ManageTeams:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.PunishmentGame:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.TeamGame:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.TeamDare:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.TeamDuel:
                        color = GetColorFromResources("OrangeCardColor");
                        break;
                    case CardSetCategory.TeamComparison:
                        color = GetColorFromResources("RedCardColor");
                        break;
                    case CardSetCategory.TeamTuneYourViolins:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.TeamChampionPreparation:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.TeamChampion:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.GameOver:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.TimeBomb:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.TeamThemedGamePreparation:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.TeamThemedGameScoring:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.TeamChampionIntroduction:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.TeamBasic:
                        color = GetColorFromResources("PurpleCardColor");
                        break;
                    case CardSetCategory.PantomimePreparation:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.StopWatch:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.PantomimeScoring:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    default:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                }

                return color;
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private Color GetColorFromResources(string key)
        {
            var color = Colors.White;
            if (App.Current.Resources.TryGetValue(key, out var colorvalue))
            {
                color = (Color)colorvalue;
            }

            return color;
        }
    }
}
