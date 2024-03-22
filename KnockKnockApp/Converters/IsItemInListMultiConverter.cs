using System.Collections;
using System.Globalization;

namespace KnockKnockApp.Converters
{
    public class IsItemInListMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var resultList = new List<PlayerWithListInfo>();

            if (values.Length != 2)
            {
                return resultList;
            }

            var list1 = values[0] as IList;
            var list2 = values[1] as IList;

            if (list1 != null)
            {
                foreach (var item in list1)
                {
                    bool isInSecondList = list2 != null && list2.Contains(item);
                    resultList.Add(new PlayerWithListInfo(item, isInSecondList));
                }
            }

            return resultList;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PlayerWithListInfo
    {
        public PlayerWithListInfo(object player, bool isInList)
        {
            Player = player;
            IsInList = isInList;
        }
        public object Player { get; set; }
        public bool IsInList { get; set; }
    }
}
