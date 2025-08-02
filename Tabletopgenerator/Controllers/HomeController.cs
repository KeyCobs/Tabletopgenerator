using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tabletopgenerator.Models;
using Tabletopgenerator.Models.ViewModel;
using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFirstNameRepository _firstNameRepository;
        private readonly INameGeneratorRepository _nameGenerator;

        public HomeController(ILogger<HomeController> logger,
                              IFirstNameRepository firstNameRepository,
                              INameGeneratorRepository nameGenerator
            )
        {
            _firstNameRepository = firstNameRepository;
            _nameGenerator = nameGenerator;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var a = await _firstNameRepository.GetAllFirstNameAsync();

            return View(a);
        }

        public async Task<IActionResult> Generate(int typeId, string gender, int raceId)
        {
            NameGeneratorViewModel randomName = await _nameGenerator.GetRandomNameAsync(raceId, typeId, gender);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
