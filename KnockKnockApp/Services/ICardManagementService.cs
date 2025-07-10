using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Services
{
    public interface ICardManagementService
    {
        public Task SetupAsync(GameMode gameMode);
        public Task<GameCardDto?> DrawNextCardAsync();
        public int GetTemplateSize();
        public int GetNumberOfPlayedTemplateCards();
    }
}
