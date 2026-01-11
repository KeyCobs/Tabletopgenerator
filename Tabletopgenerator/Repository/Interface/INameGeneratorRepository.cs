using Tabletopgenerator.Models.ViewModel;

namespace Tabletopgenerator.Repository.Interface
{
    public interface INameGeneratorRepository
    {
        public Task<NameGeneratorViewModel> GetRandomNameAsync(int raceId = 0, int typeId = 0, string gender = null);
    }
}
