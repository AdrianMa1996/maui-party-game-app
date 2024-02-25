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
                    case CardSetCategory.Basic:
                        color = GetColorFromResources("Basic");
                        break;
                    case CardSetCategory.Information:
                        color = GetColorFromResources("Information");
                        break;
                    case CardSetCategory.Game:
                        color = GetColorFromResources("Game");
                        break;
                    case CardSetCategory.Dare:
                        color = GetColorFromResources("Dare");
                        break;
                    case CardSetCategory.Duel:
                        color = GetColorFromResources("Duel");
                        break;
                    case CardSetCategory.Rule:
                        color = GetColorFromResources("Rule");
                        break;
                    case CardSetCategory.Curse:
                        color = GetColorFromResources("Curse");
                        break;
                    case CardSetCategory.Powerup:
                        color = GetColorFromResources("Powerup");
                        break;
                    default:
                        color = GetColorFromResources("Basic");
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
