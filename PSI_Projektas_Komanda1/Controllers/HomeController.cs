using Microsoft.AspNetCore.Mvc;
using PSI_Projektas_Komanda1.Models;
using System.Diagnostics;

namespace PSI_Projektas_Komanda1.Controllers
{
    public class HomeController : Controller
    {
        List<Item> items = new List<Item>();

        public void ReadItems()
        {
            Item computer = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
                5, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer1 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer2 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer3 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer4 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);

            Item smartphone = new Smartphone("/css/pictures/iphone.jpg", 2, "Apple", "iPhone", "Apple iPhone 13", "The iPhone 13 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle.", 100, "Hexa-core", 4, "A15 Bionic", 128);

            items.Add(computer);
            items.Add(computer1);
            items.Add(computer2);
            items.Add(computer3);
            items.Add(computer4);
            items.Add(smartphone);
        }

        public List<Item> filterByType(Type type)
        {
            List<Item> filtered = new List<Item>();
            foreach (Item item in items)
            {
                if (type.Equals(item.GetType())) filtered.Add(item);
            }
            return filtered;
        }

        public List<Item> filterByManyTypes(List<Type> types)
        {
            List<Item> filtered = new List<Item>();
            foreach (Item item in items)
            {
                for (int i = 0; i < types.Count; i++)
                {
                    if (types[i].Equals(item.GetType())) {
                        filtered.Add(item);
                        break;
                    }
                }
            }
            return filtered;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ReadItems();
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
            return View(items);
        }


        public IActionResult Categories()
        {          

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

        //Web models
        public IActionResult Smartphones()
        {
            return View(filterByType(typeof(Smartphone)));
        }
        public IActionResult Watches()
        {
            return View(filterByType(typeof(Watch)));
        }
        public IActionResult Computers()
        {
            return View(filterByType(typeof(Computer)));
        }
        public IActionResult Tvs()
        {
            return View(filterByType(typeof(TV)));
        }
        public IActionResult Cameras()
        {
            return View(filterByType(typeof(Camera)));
        }
        public IActionResult Fridges()
        {
            return View(filterByType(typeof(Fridge))); ;
        }
        public IActionResult Dishwashers()
        {
            return View(filterByType(typeof(Dishwasher)));
        }
        public IActionResult Microwaves()
        {
            return View(filterByType(typeof(Microwave)));
        }
        public IActionResult Stoves()
        {
            return View(filterByType(typeof(Stove)));
        }
        public IActionResult Ovens()
        {
            return View(filterByType(typeof(Oven))); 
        }
        public IActionResult VacuumCleaners()
        {
            return View(filterByType(typeof(Vacuum)));
        }
        public IActionResult WashingMachines()
        {
            return View(filterByType(typeof(WashingMashine)));
        }
        public IActionResult Dryers()
        {
            return View(filterByType(typeof(Dryer))); ;
        }
        public IActionResult AirConditioners()
        {
            return View(filterByType(typeof(AirConditioner)));
        }
        public IActionResult HeatingSystems()
        {
            return View(filterByType(typeof(HeatingSystem)));
        }
        public IActionResult Electronics()
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(Smartphone));
            types.Add(typeof(Watch));
            types.Add(typeof(Computer));
            types.Add(typeof(TV));
            types.Add(typeof(Camera));

            return View(filterByManyTypes(types));
        }
        public IActionResult KitchenAppliances()
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(Fridge));
            types.Add(typeof(Dishwasher));
            types.Add(typeof(Microwave));
            types.Add(typeof(Stove));
            types.Add(typeof(Oven));

            return View(filterByManyTypes(types));
        }
        public IActionResult HouseholdAppliances()
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(Vacuum));
            types.Add(typeof(WashingMashine));
            types.Add(typeof(Dryer));
            types.Add(typeof(AirConditioner));
            types.Add(typeof(HeatingSystem));

            return View(filterByManyTypes(types));
        }
    }
}
