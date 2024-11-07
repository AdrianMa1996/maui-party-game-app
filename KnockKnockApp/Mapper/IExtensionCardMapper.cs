using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Mapper
{
    public interface IExtensionCardMapper
    {
        public Task<ExtensionCardDto> ConvertToDtoAsync(ExtensionCard extension);
    }
}
