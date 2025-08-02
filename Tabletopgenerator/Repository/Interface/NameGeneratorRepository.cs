using Microsoft.EntityFrameworkCore;
using Tabletopgenerator.Models;
using Tabletopgenerator.Models.Entity;
using Tabletopgenerator.Models.ViewModel;
using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Repository.Interface
{
    public class NameGeneratorRepository : BaseRepository, INameGeneratorRepository
    {
        public NameGeneratorRepository(MyDbContext dbContext) : base(dbContext) { }

        public async Task<NameGeneratorViewModel> GetRandomNameAsync(int raceId = 0, int typeId = 0, string gender = "None")
        {
            Random rnd = new Random();
            raceId = await CheckIfNullAndGetRandomAsync(raceId, "Race");
            typeId = await CheckIfNullAndGetRandomAsync(typeId, "SettingType");
            gender = await CheckIfNullAndGetRandomAsync(gender);

            var firstNamesFiltered = await _dbContext.tblFirstName.Where(x => x.RaceId == raceId && x.TypeId == typeId && x.Gender == gender).OrderBy(x => rnd.Next()).FirstOrDefaultAsync();
            var lastNamesFiltered = await _dbContext.tblLastName.Where(x => x.RaceId == raceId && x.TypeId == typeId && x.Gender == gender).OrderBy(x => rnd.Next()).FirstOrDefaultAsync();

            NameGeneratorViewModel ng = new NameGeneratorViewModel
            {
                FirstName = firstNamesFiltered,
                LastName = lastNamesFiltered,
            };

            return ng;
        }


        private async Task<string> CheckIfNullAndGetRandomAsync(string gender)
        {
            Guard.AgainstNullOrWhiteSpace(gender, nameof(gender));

            if (gender == "None")
            {
                var genders = await _dbContext.tblFirstName.Select(x => x.Gender).Distinct().ToListAsync();
                int gendersLength = genders.Count;
                Random rnd = new Random();
                return genders[rnd.Next(0, gendersLength)];
            }
            Guard.CustomError(gender, nameof(gender), "NameGenerator.cs", 35);
            return "";
        }
        private async Task<int> CheckIfNullAndGetRandomAsync(int id, string objectName)
        {
            Random rnd = new Random();
            int randomId = 0;
            if (id == null && objectName == "Race")
            {
                var races = await _dbContext.tblRace.ToListAsync();
                int raceLength = races.Count;
                return races[rnd.Next(0, raceLength)].Id;
            }
            else if(id == null && objectName == "SettingType")
            {
                var settingTypes = await _dbContext.tblType.ToListAsync();
                int TypeLength = settingTypes.Count;
                return settingTypes[rnd.Next(0, TypeLength)].Id;
            }
            if (id == 0)
            {
                Guard.CustomError(id, objectName, "NameGenerator.cs", 42);
            }

            return id;
        }

    }
}
