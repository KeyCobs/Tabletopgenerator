using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tabletopgenerator.Models.ViewModel;
using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Controllers
{
    public class GeneratorController : Controller
    {
        private readonly INameGeneratorRepository _nameGeneratorRepository;
        private readonly IGeneratorRepository _generatorRepository;

        public GeneratorController
        (
            INameGeneratorRepository nameGeneratorRepository,
            IGeneratorRepository generatorRepository
        )
        {
            _nameGeneratorRepository = nameGeneratorRepository;
            _generatorRepository = generatorRepository;
        }

        public async Task<IActionResult> CharacterGenerator(GeneratedCharacterViewModel names)
        {
            var generateSettings = await _generatorRepository.GetSettignsCharacterOptionsAsync();
            if (names.FirstName != null || names.LastName != null)
            {
                generateSettings.GeneratedCharacter = names;
            }
            return View(generateSettings);
        }

        public async Task<IActionResult> Character(SettingsCharacterViewModel settings)
        {
            GeneratedCharacterViewModel names = await _nameGeneratorRepository.GetMultipleRandomNameAsync(settings);
            var generateSettings = await _generatorRepository.GetSettignsCharacterOptionsAsync();
            if (names.FirstName != null || names.LastName != null)
            {
                generateSettings.GeneratedCharacter = names;
            }
            return View("CharacterGenerator", generateSettings);
        }
    }
}
