using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Web.Models;
using System.Diagnostics;

namespace NTierArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(NTierArchitecture.DTO.DTOs.ErrorViewModels.ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}