namespace KnockKnockApp.Services
{
    public interface IManagePlayersService
    {
        public void AddPlayer(string playerName);
        public void RemovePlayer(Guid playerId);
    }
}
