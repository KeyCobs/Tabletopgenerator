using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.ViewModel
{
    public class CritereaCharacterViewModel
    {
        public Race? Race { get; set; }
        public string? Gender { get; set; }
        public SettingType? Setting { get; set; }
        public string? CustomTrait { get; set; }
        public int Amount { get; set; }
    }
}
