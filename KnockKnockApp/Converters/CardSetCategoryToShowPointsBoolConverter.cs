using KnockKnockApp.Models.Database;
using System.Globalization;

namespace KnockKnockApp.Converters
{
    class CardSetCategoryToShowPointsBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is CardSetCategory)
            {
                CardSetCategory category = (CardSetCategory)value;

                if (category == CardSetCategory.Information)
                {
                    return false;
                }
            }

            return true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
