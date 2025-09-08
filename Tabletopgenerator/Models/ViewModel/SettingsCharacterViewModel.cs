using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.ViewModel
{
    public class SettingsCharacterViewModel
    {
        public List<string>? Genders { get; set; }
        public List<Race>? Races { get; set; }
        public List<SettingType>? SettingTypes { get; set; }
        public CritereaCharacterViewModel Criterea { get; set; }
        public GeneratedCharacterViewModel GeneratedCharacter { get; set; }
    }
}
