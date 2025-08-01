using System.Collections.Generic;
using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.ViewModel
{
    public class FirstNameViewModel : FirstName
    {
        public IEnumerable<Race>? Races { get; set; }
        public IEnumerable<SettingType>? SettingTypes { get; set; }
    }
}
