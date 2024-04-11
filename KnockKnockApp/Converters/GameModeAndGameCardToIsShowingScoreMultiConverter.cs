using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Converters
{
    public class GameModeAndGameCardToIsShowingScoreMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is GameMode && values[1] is CardSet)
            {
                GameMode gameMode = (GameMode)values[0];
                CardSet cardSet = (CardSet)values[1];

                switch (cardSet.Category)
                {
                    case CardSetCategory.Information:
                        return false;
                    case CardSetCategory.Basic:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Game:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Dare:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Duel:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Rule:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Curse:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Powerup:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.ManageTeams:
                        return false;
                    case CardSetCategory.PunishmentGame:
                        return false;
                    case CardSetCategory.TeamGame:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.TeamDare:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.TeamDuel:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.Teamvergleich:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.TeamStimmtEureGeigen:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.TeamChampionPreparation:
                        return gameMode.IsTeamGameMode;
                    case CardSetCategory.TeamChampion:
                        return gameMode.IsTeamGameMode;
                    default:
                        return false;
                }
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
