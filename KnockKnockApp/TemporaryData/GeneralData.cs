using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KnockKnockApp.TemporaryData
{
    public class GeneralData : INotifyPropertyChanged
    {
        private static GeneralData _instance;

        public static GeneralData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GeneralData();
                return _instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Ab hier: Globale Properties

        public ObservableCollection<Player> _players = new ObservableCollection<Player>
        {
            new Player("Max"),
            new Player("Max Mustermann"),
            new Player("Mustermann"),
            new Player("Muster"),
            new Player("Mustermannmax"),
            new Player("Mustermann Max"),
            new Player("MaxMusterMann")
        };

        public ObservableCollection<Player> Players
        {
            get => _players;
            set
            {
                if (value == _players)
                {
                    return;
                }
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }
    }
}
