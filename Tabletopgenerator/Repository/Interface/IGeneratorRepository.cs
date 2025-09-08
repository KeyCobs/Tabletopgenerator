using Tabletopgenerator.Models.ViewModel;

namespace Tabletopgenerator.Repository.Implementation
{
    public interface IGeneratorRepository
    {
        public Task<SettingsCharacterViewModel> GetSettignsCharacterOptionsAsync();
    }
}
