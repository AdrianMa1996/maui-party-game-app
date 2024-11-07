using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Mapper
{
    public class ExtensionMapper : IExtensionMapper
    {
        private readonly IExtensionAndExtensionCardSetBindingRepository _extensionAndExtensionCardSetBindingRepository;
        private readonly IExtensionCardSetRepository _extensionCardSetRepository;
        private readonly IExtensionCardRepository _extensionCardRepository;

        public ExtensionMapper(IExtensionAndExtensionCardSetBindingRepository extensionAndExtensionCardSetBindingRepository, IExtensionCardSetRepository extensionCardSetRepository, IExtensionCardRepository extensionCardRepository)
        {
            _extensionAndExtensionCardSetBindingRepository = extensionAndExtensionCardSetBindingRepository;
            _extensionCardSetRepository = extensionCardSetRepository;
            _extensionCardRepository = extensionCardRepository;
        }

        public async Task<ExtensionDto> ConvertToDtoAsync(Extension extension)
        {
            var extensionDto = new ExtensionDto()
            {
                ExtensionDetails = extension,
                ExtensionCardSets = await GetExtensionCardSetDtoListAsync(extension)
            };
            return extensionDto;
        }

        private async Task<List<ExtensionCardSetDto>> GetExtensionCardSetDtoListAsync(Extension extension)
        {
            var extensionCardSetDtoList = new List<ExtensionCardSetDto>();

            var extensionAndExtensionCardSetBindingList = await _extensionAndExtensionCardSetBindingRepository.GetExtensionAndExtensionCardSetBindingsByExtensionIdAsync(extension.ExtensionID);

            foreach (var extensionAndExtensionCardSetBinding in extensionAndExtensionCardSetBindingList)
            {
                var extensionCardSet = await _extensionCardSetRepository.GetExtensionCardSetByIdAsync(extensionAndExtensionCardSetBinding.ExtensionCardSetID);
                var extensionCardList = await _extensionCardRepository.GetExtensionCardListByExtensionCardSetIdAsync(extensionCardSet.ExtensionCardSetID);
                var extensionCardSetDto = new ExtensionCardSetDto()
                {
                    ExtensionCardSetDetails = extensionCardSet,
                    ExtensionBindingDetails = extensionAndExtensionCardSetBinding,
                    ExtensionDetails = extension,
                    ExtensionCards = extensionCardList
                };

                extensionCardSetDtoList.Add(extensionCardSetDto);
            }

            return extensionCardSetDtoList;
        }
    }
}
