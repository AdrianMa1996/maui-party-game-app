using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Mapper
{
    public class ExtensionCardMapper : IExtensionCardMapper
    {
        private readonly IExtensionCardSetRepository _extensionCardSetRepository;

        public ExtensionCardMapper(IExtensionCardSetRepository extensionCardSetRepository)
        {
            _extensionCardSetRepository = extensionCardSetRepository;
        }

        public async Task<ExtensionCardDto> ConvertToDtoAsync(ExtensionCard extensionCard)
        {
            var extensionCardSet = await _extensionCardSetRepository.GetExtensionCardSetByIdAsync(extensionCard.ExtensionCardSetID);
            return new ExtensionCardDto()
            {
                ExtensionCardDetails = extensionCard,
                ExtensionCardSetDetails = extensionCardSet
            };
        }
    }
}
