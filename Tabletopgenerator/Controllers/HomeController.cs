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

        public HomeController(ILogger<HomeController> logger,
                              IFirstNameRepository firstNameRepository                  
            )
        {
            _firstNameRepository = firstNameRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var a = await _firstNameRepository.GetAllFirstNameAsync();

            return View(a);
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
