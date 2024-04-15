using KnockKnockApp.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace KnockKnockApp.Services
{
    public interface ILocalizationService
    {
        public void SetCulture(CultureInfo culture);
        public CultureInfo GetCulture();
        public ObservableCollection<Localization> GetLocalizations();
    }
}
