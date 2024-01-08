using DemoASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace DemoASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Random()
        {
            return View();
        }
        public IActionResult MyError404()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()

        {
            ViewData["Title"] = "Test";
            ViewBag.Test = "ouiControl";
            TempData["Test"] = "nonControl";

            return View();
        }
        public IActionResult TestData2()

        {


            return View();
        }
        public IActionResult TestData3()

        {
            ViewData["Title"] = "TestData3";
            ViewBag.Test = "ouiControltest3";
            TempData["Test"] = "nonControltest3";

            return RedirectToAction("TestData2");
        }
        public IActionResult TestData4()

        {
            ViewData["Title"] = "TestData4";
            ViewBag.Test = "ouiControltest4";
            TempData["Test"] = "nonControltest4";

            return RedirectToAction("TestData");
        }

        
        public IActionResult TestData()
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
            
            
        



    
    


    

