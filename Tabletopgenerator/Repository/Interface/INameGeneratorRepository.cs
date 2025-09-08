using Tabletopgenerator.Models.ViewModel;

namespace Tabletopgenerator.Repository.Implementation
{
    public interface INameGeneratorRepository
    {
        public Task<GeneratedCharacterViewModel> GetMultipleRandomNameAsync(SettingsCharacterViewModel setting);
    }
}
