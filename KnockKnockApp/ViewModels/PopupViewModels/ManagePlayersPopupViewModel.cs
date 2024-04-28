using CommunityToolkit.Mvvm.ComponentModel;
using KnockKnockApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.ViewModels.PopupViewModels
{
    public partial class ManagePlayersPopupViewModel : ObservableObject
    {
        public ManagePlayersPopupViewModel(ILocalizationService localizationService)
        {
            LocalizationService = localizationService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;
    }
}
