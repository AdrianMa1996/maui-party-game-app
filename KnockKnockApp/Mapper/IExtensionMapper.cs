using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Mapper
{
    public interface IExtensionMapper
    {
        public Task<ExtensionDto> ConvertToDtoAsync(Extension extension);
    }
}
