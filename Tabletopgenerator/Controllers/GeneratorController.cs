using Microsoft.AspNetCore.Mvc;
using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Controllers
{
    public class GeneratorController : Controller
    {
        private readonly INameGeneratorRepository _nameGeneratorRepository;

        public GeneratorController(INameGeneratorRepository nameGeneratorRepository)
        {
            _nameGeneratorRepository = nameGeneratorRepository;
        }

        public IActionResult CharacterGenerator()
        {
            return View();
        }
    }
}
