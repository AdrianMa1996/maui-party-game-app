using KnockKnockApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Services
{
    class TeamManagementService : ITeamManagementService
    {
        private Team teamOne;
        private Team teamTwo;

        private Team winningTeam;
        private Team losingTeam;

        public void SetupTeamManagementService()
        {
            teamOne = new Team("TeamA", 0);
            teamTwo = new Team("TeamB", 0);
            resetLosingAndWinningTeams();
            return;
        }

        public Team GetTeamOne()
        {
            return teamOne;
        }

        public void AddGamePointsToTeamOne(int gamePoints)
        {
            teamOne.GamePoints = teamOne.GamePoints + gamePoints;
            resetLosingAndWinningTeams();
            return;
        }

        public Team GetTeamTwo()
        {
            return teamTwo;
        }

        public void AddGamePointsToTeamTwo(int gamePoints)
        {
            teamTwo.GamePoints = teamTwo.GamePoints + gamePoints;
            resetLosingAndWinningTeams();
            return;
        }

        public Team GetWinningTeam()
        {
            return winningTeam;
        }

        public Team GetLosingTeam()
        {
            return losingTeam;
        }

        private void resetLosingAndWinningTeams()
        {
            if (teamOne.GamePoints <= teamTwo.GamePoints)
            {
                winningTeam = teamOne;
                losingTeam = teamTwo;
            }
            else
            {
                winningTeam = teamTwo;
                losingTeam = teamOne;
            }
        }
    }
}
