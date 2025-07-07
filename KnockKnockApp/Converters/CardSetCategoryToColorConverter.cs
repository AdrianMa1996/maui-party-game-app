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
                    case CardSetCategory.ManageTeams:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.PunishmentGame:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.PurpleCard:
                        color = GetColorFromResources("PurpleCardColor");
                        break;
                    case CardSetCategory.PurpleCardScoring:
                        color = GetColorFromResources("PurpleCardColor");
                        break;
                    case CardSetCategory.YellowCard:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.YellowCardScoring:
                        color = GetColorFromResources("YellowCardColor");
                        break;
                    case CardSetCategory.GreenCard:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.GreenCardScoring:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case CardSetCategory.BlueCard:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.BlueCardScoring:
                        color = GetColorFromResources("BlueCardColor");
                        break;
                    case CardSetCategory.RedCard:
                        color = GetColorFromResources("RedCardColor");
                        break;
                    case CardSetCategory.RedCardScoring:
                        color = GetColorFromResources("RedCardColor");
                        break;
                    case CardSetCategory.PinkCard:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.PinkCardScoring:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.OrangeCard:
                        color = GetColorFromResources("OrangeCardColor");
                        break;
                    case CardSetCategory.OrangeCardScoring:
                        color = GetColorFromResources("OrangeCardColor");
                        break;
                    case CardSetCategory.GrayCard:
                        color = GetColorFromResources("GrayCardColor");
                        break;
                    case CardSetCategory.GrayCardScoring:
                        color = GetColorFromResources("GrayCardColor");
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
                    case CardSetCategory.StopWatchPreparation:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.StopWatch:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case CardSetCategory.StopWatchScoring:
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
