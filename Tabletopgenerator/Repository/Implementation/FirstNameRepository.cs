using Microsoft.EntityFrameworkCore;
using Tabletopgenerator.Models;
using Tabletopgenerator.Models.Entity;
using Tabletopgenerator.Repository;
using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Repository.Implementation
{
    public class FirstNameRepository : BaseRepository, IFirstNameRepository
    {
        public FirstNameRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<FirstName>> GetAllFirstNameAsync()
        {
            return await _dbContext.tblFirstName.ToListAsync();
        }

        public async Task<IEnumerable<string?>> GetAllNamesAsync()
        {
            return await _dbContext.tblFirstName.Select(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<FirstName>> GetRandomAmountFirstNamesAsync(int number)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetRandomAmountNamesAsync(int number)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRandomFirstNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRandomNameAsync()
        {
            throw new NotImplementedException();
        }
    }
}
