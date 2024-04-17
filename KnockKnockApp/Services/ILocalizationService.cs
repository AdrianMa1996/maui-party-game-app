using KnockKnockApp.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace KnockKnockApp.Services
{
    public interface ILocalizationService
    {
        public void SetCurrentLocalization(Localization localization);
        public Localization GetCurrentLocalization();
        public ObservableCollection<Localization> GetLocalizations();
    }
}
