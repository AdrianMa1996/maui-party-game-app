using KnockKnockApp.Models.Database;
using System.Globalization;

namespace KnockKnockApp.Converters
{
    public class ExtensionCardSetCategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExtensionCardSetCategory)
            {
                ExtensionCardSetCategory category = (ExtensionCardSetCategory)value;
                Color color;

                switch (category)
                {
                    case ExtensionCardSetCategory.ThemedGamePreparation:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case ExtensionCardSetCategory.ThemedGame:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case ExtensionCardSetCategory.ThemedGameCompletion:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case ExtensionCardSetCategory.RhymingGamePreparation:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case ExtensionCardSetCategory.RhymingGame:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case ExtensionCardSetCategory.RhymingGameCompletion:
                        color = GetColorFromResources("GreenCardColor");
                        break;
                    case ExtensionCardSetCategory.MimePreparation:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case ExtensionCardSetCategory.Mime:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case ExtensionCardSetCategory.MimeCompletion:
                        color = GetColorFromResources("PinkCardColor");
                        break;
                    case ExtensionCardSetCategory.GameRule:
                        color = GetColorFromResources("RedCardColor");
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
