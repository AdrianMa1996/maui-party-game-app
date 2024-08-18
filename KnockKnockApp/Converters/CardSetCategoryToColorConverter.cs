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
                    case CardSetCategory.GameOver:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.Basic:
                        color = GetColorFromResources("PurpleCardColor");
                        break;
                    case CardSetCategory.Duel:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.Game:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.Dare:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.Rule:
                        color = GetColorFromResources("RedCardColor");
                        break;
                    case CardSetCategory.Powerdown:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.Powerup:
                        color = GetColorFromResources("OrangeCardColor");
                        break;
                    case CardSetCategory.InformationTeams:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.GameOverTeams:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.ManageTeams:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.PunishmentGame:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.TeamBasic:
                        color = GetColorFromResources("PurpleCardColor");
                        break;
                    case CardSetCategory.TimeBombPreparation:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.TimeBomb:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.TimeBombScoring:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.TeamDare:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.TeamTuneYourViolins:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.StopWatchPreparation:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.StopWatch:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.StopWatchScoring:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.KnockKnockGlasTrinken:
                        color = GetColorFromResources("RedCardColor");
                        break;
                    case CardSetCategory.KnockKnockGlasBefüllen:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.KnockKnockGlasWeitergeben:
                        color = GetColorFromResources("GreenCardColor");
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
