using CommunityToolkit.Mvvm.ComponentModel;
using KnockKnockApp.Models;
using KnockKnockApp.Resources.Languages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace KnockKnockApp.Services
{
    [ObservableObject]
    public partial class LocalizationService : ILocalizationService
    {
        private Localization _currentLocalization;

        private ObservableCollection<Localization> localizations = [
            new Localization("Deutschland", new CultureInfo("de-DE"), "flag_germany.png")];
        // new Localization("Großbritannien", new CultureInfo("en-GB"), "flag_united_kingdom.png")];

        public LocalizationService()
        {
            var currentCultureInfo = CultureInfo.CurrentCulture;
            _currentLocalization = localizations.FirstOrDefault(l => l.Culture.Equals(currentCultureInfo)) ?? localizations.FirstOrDefault(l => l.Culture.Name == "de-DE");
        }

        public object this[string resourceKey]
            => AppResources.ResourceManager.GetObject(resourceKey, _currentLocalization.Culture) ?? Array.Empty<byte>();

        public void SetCurrentLocalization(Localization localization)
        {
            _currentLocalization = localization;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public Localization GetCurrentLocalization()
        {
            return _currentLocalization;
        }

        public ObservableCollection<Localization> GetLocalizations()
        {
            return localizations;
        }
    }
}
