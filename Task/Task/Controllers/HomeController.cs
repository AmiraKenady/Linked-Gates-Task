using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task.Models;
using Task.Services.Category;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryServices CategoryService;

        public HomeController(ICategoryServices _CategoryService)
        {
            CategoryService = _CategoryService;
        }

        public IActionResult Index()
        {
            var Categries= CategoryService.GetAllCategories();
            return View(Categries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}