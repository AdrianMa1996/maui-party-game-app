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
        private CultureInfo _culture;

        private ObservableCollection<Localization> localizations = [
            new Localization("Deutschland", new CultureInfo("de-DE")), 
            new Localization("Frankreich", new CultureInfo("fr-FR")),
            new Localization("Großbritannien", new CultureInfo("en-GB")),
            new Localization("Niederlande", new CultureInfo("nl-NL"))];

        public LocalizationService()
        {
            _culture = CultureInfo.CurrentCulture;
        }

        public object this[string resourceKey]
            => AppResources.ResourceManager.GetObject(resourceKey, _culture) ?? Array.Empty<byte>();

        public void SetCulture(CultureInfo culture)
        {
            _culture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public CultureInfo GetCulture()
        {
            return _culture;
        }

        public ObservableCollection<Localization> GetLocalizations()
        {
            return localizations;
        }
    }
}
