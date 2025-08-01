using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Repository.Implementation
{
    public interface IFirstNameRepository
    {
        public Task<IEnumerable<FirstName>> GetAllFirstNameAsync();
        public Task<IEnumerable<string?>> GetAllNamesAsync();
        public Task<IEnumerable<FirstName>> GetRandomAmountFirstNamesAsync(int number);
        public Task<IEnumerable<string?>> GetRandomAmountNamesAsync(int number);
        public Task<string?> GetRandomNameAsync();
        public Task<string?> GetRandomFirstNameAsync();

    }
}
