using Microsoft.AspNetCore.Mvc;
using PSI_Projektas_Komanda1.Models;
using System.Diagnostics;

namespace PSI_Projektas_Komanda1.Controllers
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
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Categories()
        {
            ViewBag.Items = new List<Item>()
            {
                new Dishwasher(111, "LG", "s1", "Indaplovė1", "------------------------------------------------------------------------------------------------------------", 6, 80.5),
                new Dishwasher(112, "Samsung", "s2", "Indaplovė2", "--------------------------------------------------------------------------------------------------------", 5, 81.6),
                new Camera(211, "Samsung", "s3", "Kamera1", "--------------------------", 8, 20),
                new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
                new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
                new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
                new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),

				new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
				new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
				new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
				new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
				new Microwave(311, "LG", "s4", "Mikrobangė", "-------------------------------", 20, 500),
				new Microwave(311, "LG", "s4", "Mikrobangė", "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 20, 500),


			};

            return View();
        }
        public IActionResult Contact()
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