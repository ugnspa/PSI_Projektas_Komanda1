using Microsoft.AspNetCore.Mvc;
using PSI_Projektas_Komanda1.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using System.Text.Json;
using PSI_Projektas_Komanda1.Repositories;
using MySqlX.XDevAPI;
using System;
using System.Text.RegularExpressions;

namespace PSI_Projektas_Komanda1.Controllers
{

    public class HomeController : Controller 
    {
        List<Item> items = new List<Item>();
        List<Item> popular =new List<Item>(); // popular items

        public void ReadItems()
        {
           
            items = AirConditionerRepo.ReadAirConditioners();
            items.AddRange(CameraRepo.ReadCameras());
            items.AddRange(ComputerRepo.ReadComputers());
            items.AddRange(DishwasherRepo.ReadDiswashers());
            items.AddRange(DryerRepo.ReadDryers());
            items.AddRange(FridgeRepo.ReadFridges());
            items.AddRange(HeatingSystemRepo.ReadHeatingSystems());
            items.AddRange(MicrowaveRepo.ReadMicrowaves());
            items.AddRange(OvenRepo.ReadOvens());
            items.AddRange(SmartphoneRepo.ReadSmartphones());
            items.AddRange(StoveRepo.ReadStoves());
            items.AddRange(TVRepo.ReadTVs());
            items.AddRange(VacuumRepo.ReadVacuums());
            items.AddRange(WashingMachineRepo.ReadWashingMachines());
            items.AddRange(WatchRepo.ReadWatches());

            popular.AddRange(ComputerRepo.SelectFirstTen());
            Console.WriteLine(popular.Count);
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
            _logger = logger;;
            ReadItems();
        }

        public IActionResult Index()
        {

            return View(popular);
        }

        public IActionResult Privacy()
        {
            return View();
        }
   
        public IActionResult Contact()
        {
            return View();
        }
	
	public decimal ConvertPrice(decimal price, string currency)
        {
            decimal baseRate = 1.0m; // Default exchange rate is 1:1
           
            if (currency == "usd")
            {
                baseRate = 1.07m; // EUR to USD exchange rate
               
            }
            else if (currency == "gbp")
            {
                baseRate = 0.88m; // EUR to GBP exchange rate
                
            }
            return Math.Round(price * baseRate, 2);
        }
	
	public IActionResult Store(string currency)
        {           
            // Convert all item prices to the new currency
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }

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

        //search method
        /*public IActionResult SearchForm()
        {
            return View("SearchForm");
        }*/

        public IActionResult SearchForName(string query, string currency)
        {
            ViewBag.SearchName = query;
            List<Item> searchedItems= new List<Item>();
            try
            {
                foreach (Item item in items)
                {
                    if (Regex.IsMatch(item.Name.ToLower(), query.ToLower()))
                        searchedItems.Add(item);
			item.Price = ConvertPrice(item.Price, currency);

                }
                if (searchedItems.Count == 0)
                {
                    return View("NoResultsFound");
                }
                else return View("SearchForName", searchedItems);
            }
            catch
            {
                return View("NoResultsFound");
            }
        }

		public IActionResult Search(string query)
		{
            var results = items.Where(i => i.Name.ToLower().Contains(query.ToLower()))
                   .Select(i => i.Name)
                   .Take(10)
                   .ToList();
            return Json(results);
        }

		//Web models
    public IActionResult Smartphones(string currency)

        {
            var model = filterByType(typeof(Smartphone));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Smartphones.cshtml", model);
        }
        public IActionResult Watches(string currency)
        {
            var model = filterByType(typeof(Watch));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Watches.cshtml", model);
        }
        public IActionResult Computers(string currency)
        {
            var model = filterByType(typeof(Computer));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Computers.cshtml", model);
        }
        public IActionResult Tvs(string currency)
        {
            var model = filterByType(typeof(TV));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Tvs.cshtml", model);
        }
        public IActionResult Cameras(string currency)
        {
            var model = filterByType(typeof(Camera));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Cameras.cshtml", model);
        }
        public IActionResult Fridges(string currency)
        {
            var model = filterByType(typeof(Fridge));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Fridges.cshtml", model);
        }
        public IActionResult Dishwashers(string currency)
        {
            var model = filterByType(typeof(Dishwasher));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Dishwashers.cshtml", model);
        }
        public IActionResult Microwaves(string currency)
        {
            var model = filterByType(typeof(Microwave));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Microwaves.cshtml", model);
        }
        public IActionResult Stoves(string currency)
        {
            var model = filterByType(typeof(Stove));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Stoves.cshtml", model);
        }
        public IActionResult Ovens(string currency)
        {
            var model = filterByType(typeof(Oven));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Ovens.cshtml", model);
        }
        public IActionResult VacuumCleaners(string currency)
        {
            var model = filterByType(typeof(Vacuum));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/VacuumCleaners.cshtml", model);
        }
        public IActionResult WashingMachines(string currency)
        {
            var model = filterByType(typeof(WashingMashine));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/WashingMachines.cshtml", model);
        }
        public IActionResult Dryers(string currency)
        {
            var model = filterByType(typeof(Dryer));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/Dryers.cshtml", model);
        }
        public IActionResult AirConditioners(string currency)
        {
            var model = filterByType(typeof(AirConditioner));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/AirConditioners.cshtml", model);
        }
        public IActionResult HeatingSystems(string currency)
        {
            var model = filterByType(typeof(HeatingSystem));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }
            return View("~/Views/Home/HeatingSystems.cshtml", model); ;
        }
        public IActionResult Electronics(string currency)
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(Smartphone));
            types.Add(typeof(Watch));
            types.Add(typeof(Computer));
            types.Add(typeof(TV));
            types.Add(typeof(Camera));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }

            var model = filterByManyTypes(types);
            return View("~/Views/Home/Electronics.cshtml", model);
        }
        public IActionResult KitchenAppliances(string currency)
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(Fridge));
            types.Add(typeof(Dishwasher));
            types.Add(typeof(Microwave));
            types.Add(typeof(Stove));
            types.Add(typeof(Oven));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }

            var model = filterByManyTypes(types);
            return View("~/Views/Home/KitchenAppliances.cshtml", model);
        }
        public IActionResult HouseholdAppliances(string currency)
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(Vacuum));
            types.Add(typeof(WashingMashine));
            types.Add(typeof(Dryer));
            types.Add(typeof(AirConditioner));
            types.Add(typeof(HeatingSystem));
            foreach (var item in items)
            {
                item.Price = ConvertPrice(item.Price, currency);
            }

            var model = filterByManyTypes(types);
            return View("~/Views/Home/HouseholdAppliances.cshtml", model);
        }



        // Cart
        public Item getItem(int id, string name)
        {
            if (name == null || id<=0)
            {
                throw new ArgumentNullException(nameof(name));
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(name) && items[i].Id==id)
                {
                    return items[i];
                }
            }
            return null;
        }

        public IActionResult AddToCart(int id, string name)
        {
            Item item = getItem(id,name);
            if (item == null)
            {
                return BadRequest("Item not found");
            }

            Order order = HttpContext.Session.Get<Order>("order");
            if (order == null)
            {
                order = new Order();
            }

            order.Add(item);
            Console.WriteLine(((Order)order).count().ToString());
            HttpContext.Session.Set("order", (Order)order);
            Order order1 = HttpContext.Session.Get<Order>("order");
            Console.WriteLine(((Order)order1).count().ToString());

            return Ok();
        }

        public IActionResult Cart()
        {
            Order order = HttpContext.Session.Get<Order>("order");
            if (order == null)
            {
                return View(new Order());
            }

            return View(order);
        }
	
	 public IActionResult ItemDetails(string name)
        {

            var item = items.FirstOrDefault(i => i.Name == name);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        } 
    }
}
