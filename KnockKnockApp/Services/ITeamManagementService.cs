using KnockKnockApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Services
{
    public interface ITeamManagementService
    {
        public void SetupTeamManagementService();
        public Team GetTeamOne();
        public void AddGamePointsToTeamOne(int gamePoints);
        public Team GetTeamTwo();
        public void AddGamePointsToTeamTwo(int gamePoints);
        public Team GetWinningTeam();
        public Team GetLosingTeam();
    }
}
