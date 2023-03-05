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
   
        public IActionResult Contact()
        {
            return View();
        }
	
	  public IActionResult Store()
        {
            var computer = new Computer(1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
                5, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);

            var smartphone = new Smartphone(2, "Apple", "iPhone", "Apple iPhone 13", "The iPhone 13 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle.", 100, "Hexa-core", 4, "A15 Bionic", 128);

            var viewModel = new HomeViewModel
            {
                Computer = computer,
                Smartphone = smartphone,
                ComputerImageUrl = "https://i.dell.com/is/image/DellContent//content/dam/images/products/laptops-and-2-in-1s/inspiron/15-5510-non-touch/in5510nt-cnb-00055lf110-gy-backlit.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=631&qlt=100,1&resMode=sharp2&size=631,402&chrss=full", // Replace with the URL of your image
                SmartphoneImageUrl = "https://media.croma.com/image/upload/v1664009258/Croma%20Assets/Communication/Mobiles/Images/243459_0_ljp1lm.png"
            };          
            return View(viewModel);
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
	   public IActionResult About()
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
