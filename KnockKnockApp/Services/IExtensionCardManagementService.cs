using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Services
{
    public interface IExtensionCardManagementService
    {
        public Task SetupAsync(Extension extension);
        public Task<ExtensionCardDto?> DrawNextExtensionCardAsync();
    }
}
