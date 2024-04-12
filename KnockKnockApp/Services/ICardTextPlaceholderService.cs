using KnockKnockApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Services
{
    public interface ICardTextPlaceholderService
    {
        public void SetupAndShuffleLists();
        public GameCard ResolvePlayerPlaceholders(GameCard gameCard);
        public GameCard ResolveWinningTeamPlaceholders(GameCard gameCard);
        public GameCard ResolveLosingTeamPlaceholders(GameCard gameCard);
        public GameCard ResolvePointValuePlaceholders(GameCard gameCard);
        public GameCard ResolveTeamPlaceholders(GameCard gameCard);
        public GameCard ResolvePlayerTeam1Placeholders(GameCard gameCard);
        public GameCard ResolvePlayerTeam2Placeholders(GameCard gameCard);
    }
}
