using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        // Ab hier: Zum Testen, kommt später in die Datenbank

        public ObservableCollection<GameMode> _gameModes = new ObservableCollection<GameMode>
        {
            new GameMode() { GameModeID = 1, Title = "GameModeTitle1", Image = "GameModeTitle1", DescriptionText = "Beispielbeschreibung", IsPrime = false },
            new GameMode() { GameModeID = 1, Title = "GameModeTitle1", Image = "GameModeTitle1", DescriptionText = "Beispielbeschreibung", IsPrime = false }
        };

        public ObservableCollection<GameMode> GameModes
        {
            get => _gameModes;
            set
            {
                if (value == _gameModes)
                {
                    return;
                }
                _gameModes = value;
                OnPropertyChanged(nameof(GameModes));
            }
        }
    }
}
