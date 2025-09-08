using Microsoft.EntityFrameworkCore;
using Tabletopgenerator.Models;
using Tabletopgenerator.Models.ViewModel;

namespace Tabletopgenerator.Repository.Implementation
{
    public class GeneratorRepository : BaseRepository, IGeneratorRepository
    {
        public GeneratorRepository(MyDbContext dbContext) : base(dbContext){}

        public async Task<SettingsCharacterViewModel> GetSettignsCharacterOptionsAsync()
        {
            SettingsCharacterViewModel cr = new SettingsCharacterViewModel
            {
                Genders = await _dbContext.tblFirstName.Select(x => x.Gender).Distinct().ToListAsync(),
                Races = await _dbContext.tblRace.ToListAsync(),
                SettingTypes = await _dbContext.tblSettingType.ToListAsync()
            };

            return cr;
        }
    }
}
