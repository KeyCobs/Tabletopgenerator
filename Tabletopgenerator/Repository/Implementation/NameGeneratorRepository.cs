using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Tabletopgenerator.Models;
using Tabletopgenerator.Models.Entity;
using Tabletopgenerator.Models.ViewModel;
using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Repository.Interface
{
    public class NameGeneratorRepository : BaseRepository, INameGeneratorRepository
    {
        public NameGeneratorRepository(MyDbContext dbContext) : base(dbContext) { }

        public async Task<GeneratedCharacterViewModel> GetMultipleRandomNameAsync(SettingsCharacterViewModel setting)
        {
            CritereaCharacterViewModel criterea = setting.Criterea;

            Guard.AgainstNull(criterea, nameof(criterea));
            if(criterea.Amount > 100) Guard.CustomError(criterea.Amount, nameof(criterea.Amount),"CharacterGenerator","111");

            Random rnd = new Random();
            var firstNameListDb = await _dbContext.tblFirstName.ToListAsync();
            var lastNameListDb = await _dbContext.tblLastName.ToListAsync();
            List<FirstName> firstNameRandomList = new List<FirstName>();
            List<LastName> lastNameRandomList = new List<LastName>();
            var filteredFirst = firstNameListDb.Where(x => (criterea.Race.Id == 0 || x.RaceId == criterea.Race.Id) &&
                                                (criterea.Setting.Id == 0 || x.TypeId == criterea.Setting.Id) &&
                                                (string.IsNullOrEmpty(criterea.Gender) || x.Gender == criterea.Gender))
                                               .ToList();

            var filteredLast = lastNameListDb.Where(x => (criterea.Race.Id == 0 || x.RaceId == criterea.Race.Id) &&
                                                        (criterea.Setting.Id == 0 || x.TypeId == criterea.Setting.Id) &&
                                                        (string.IsNullOrEmpty(criterea.Gender) || x.Gender == criterea.Gender))
                                             .ToList();


            for (int i = 0; i < criterea.Amount; i++)
            {
                firstNameRandomList.Add(filteredFirst[rnd.Next(filteredFirst.Count)]);
                lastNameRandomList.Add(filteredLast[rnd.Next(filteredLast.Count)]);
            }


            GeneratedCharacterViewModel generatedCharacter = new GeneratedCharacterViewModel
            {
                FirstName = firstNameRandomList,
                LastName = lastNameRandomList
            };

            return generatedCharacter;
        }

        public Task<GeneratedCharacterViewModel> GetRandomNameAsync(int raceId = 0, int typeId = 0, string gender = null)
        {
            throw new NotImplementedException();
        }

        //private async Task<string> CheckIfNullAndGetRandomAsync(string gender)
        //{
        //    Guard.AgainstNullOrWhiteSpace(gender, nameof(gender));

        //    if (gender == "None")
        //    {
        //        var genders = await _dbContext.tblFirstName.Select(x => x.Gender).Distinct().ToListAsync();
        //        int gendersLength = genders.Count;
        //        Random rnd = new Random();
        //        return genders[rnd.Next(0, gendersLength)];
        //    }
        //    Guard.CustomError(gender, nameof(gender), "NameGenerator.cs", 35);
        //    return "";
        //}
        //private async Task<int> CheckIfNullAndGetRandomAsync(int id, string objectName)
        //{
        //    Random rnd = new Random();
        //    int randomId = 0;
        //    if (id == null && objectName == "Race")
        //    {
        //        var races = await _dbContext.tblRace.ToListAsync();
        //        int raceLength = races.Count;
        //        return races[rnd.Next(0, raceLength)].Id;
        //    }
        //    else if(id == null && objectName == "SettingType")
        //    {
        //        var settingTypes = await _dbContext.tblSettingType.ToListAsync();
        //        int TypeLength = settingTypes.Count;
        //        return settingTypes[rnd.Next(0, TypeLength)].Id;
        //    }
        //    if (id == 0)
        //    {
        //        Guard.CustomError(id, objectName, "NameGenerator.cs", 42);
        //    }

        //    return id;
        //}

    }
}
