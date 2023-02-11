using DB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryServices CategoryService;
        private readonly IdeviceServices DeviceServices;
        private readonly IpropertyServices propertyServices;

        public HomeController(ICategoryServices _CategoryService, IdeviceServices _deviceServices, IpropertyServices _IpropertyServices)
        {
            CategoryService = _CategoryService;
            DeviceServices = _deviceServices;
            propertyServices = _IpropertyServices;
        }

        public IActionResult Index()
        {
            ViewBag.devices = DeviceServices.GetDevices();
            return View();
        }

        [HttpGet]
        public IActionResult AddDevice(int catid)
        {
            ViewBag.prop = propertyServices.getProperties(catid);
            ViewBag.Category = CategoryService.GetAllCategories();

            return View();

        }
        [HttpPost]
        public IActionResult AddDevice(DeviceViewModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                
                DeviceServices.AddDeviceAndProprty(deviceModel);
                return RedirectToAction("Index");
            }
            else
            {
                var errors =
                ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                    ModelState.AddModelError("", err);
                ViewBag.Category = CategoryService.GetAllCategories();
                return View();

            }

        }

        [HttpGet]
        public JsonResult GetProperties(int catid/*, PropertiesValuesViewModel PropModel*/)
        {
            //propertyServices.AddPropertiesValues(PropModel);
            var x = propertyServices.getProperties(catid);
            return Json(x);
        }

        public IActionResult EditDevice(DeviceViewModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                DeviceServices.EditDevice(deviceModel);
                return RedirectToAction("Index");
            }
            else
            {
                var errors =
                ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                    ModelState.AddModelError("", err);
                ViewBag.Category = CategoryService.GetAllCategories();
                return View();
            }
          
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}