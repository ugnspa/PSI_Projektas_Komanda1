using Microsoft.AspNetCore.Mvc;
using PSI_Projektas_Komanda1.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using PSI_Projektas_Komanda1.Repositories;
using MySqlX.XDevAPI;
using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace PSI_Projektas_Komanda1.Controllers
{

    public class HomeController : Controller
    {
        List<Item> items = new List<Item>();
        List<Item> popular = new List<Item>(); // popular items

        Cart cart = new Cart();

        List<int> test;

        Dictionary<Item, int> cartDic = new Dictionary<Item, int>();
        public void ReadItems()
        {
            Item computer1 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, 599, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer2 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, 599, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer3 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, 599, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer4 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "Inspiron", "Dell Inspiron 15", "A powerful laptop for gaming and productivity",
               5, 599, "Intel Core i7", "Intel H370", "NVIDIA GeForce GTX 1650", 16, 512, 600);
            Item computer5 = new Computer("https://www.bekredito.lt/wp-content/uploads/2022/08/lenovo-82jw00jbpb-legion-5-15ach-PG57330978BK.jpg16614606762097-400x400.jpg", 1, "Lenovo", "Legion", "Lenovo Legion Y740", "A high-end gaming laptop with a sleek design",
                4, 599, "Intel Core i9", "Intel Z390", "NVIDIA GeForce RTX 2080 Max-Q", 32, 1_000, 2_499);
            Item computer6 = new Computer("https://img.computerunivers.net/images/400x400/908930009EE7FD11CE044DEC89789248.jpg", 1, "ASUS", "ROG", "ASUS ROG Strix G17", "A powerful gaming laptop with an eye-catching design",
                            4, 599, "AMD Ryzen 9", "AMD X570", "NVIDIA GeForce RTX 3070", 32, 1_000, 1_999);
            Item computer7 = new Computer("https://cdn.mall.adeptmind.ai/https%3A%2F%2Fmultimedia.bbycastatic.ca%2Fmultimedia%2Fproducts%2F500x500%2F163%2F16378%2F16378368_5.jpeg_medium.jpg", 1, "MSI", "GS", "MSI GS75 Stealth", "A slim gaming laptop with powerful hardware",
                            4, 599, "Intel Core i7", "Intel HM370", "NVIDIA GeForce RTX 2080 Max-Q", 32, 512, 2_399);
            Item computer8 = new Computer("https://multitech-lb.com/wp-content/uploads/multitech-lebanon-ACER-PREDATOR-HELIOS-300-PH315-55-70ZV-400x400.jpg", 1, "Acer", "Predator", "Acer Predator Helios 300", "A budget-friendly gaming laptop with solid performance",
                            4, 599, "Intel Core i7", "Intel HM470", "NVIDIA GeForce RTX 3060", 16, 512, 1_199);
            Item computer9 = new Computer("https://img.computerunivers.net/images/400x400/9085658730D6D54ECED743D08741D389.jpg", 1, "Razer", "Blade", "Razer Blade Pro 17", "A premium gaming laptop with top-of-the-line specs",
                            4, 599, "Intel Core i9", "Intel HM470", "NVIDIA GeForce RTX 3080", 32, 1_000, 3_799);
            Item computer10 = new Computer("https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_3ZV24EA-ABU_ProductPicture.jpg", 1, "HP", "Omen", "HP Omen 15", "A powerful gaming laptop with a minimalist design",
                            4, 599, "AMD Ryzen 7", "AMD X570", "NVIDIA GeForce RTX 3070", 16, 512, 1_299);
            Item computer11 = new Computer("https://img.computerunivers.net/images/400x400/908325176DACF9381ABB4EA3BC9259E1.jpg", 1, "Lenovo", "ThinkPad", "Lenovo ThinkPad X1 Carbon", "A business laptop with strong performance and security features",
                            4, 599, "Intel Core i7", "Intel vPro", "Intel UHD Graphics 620", 16, 512, 1_449);
            Item computer12 = new Computer("https://kainos-img.dgn.lt/photos2_25_62424323/asus-zenbook-ux425ja-hm254t-14-fhd-ips-i5-1035g1-8gb-512ssd-w10.jpg", 1, "ASUS", "ZenBook", "ASUS ZenBook 14", "An ultraportable laptop with a stunning display",
                            4, 599, "Intel Core i7", "Intel HM470", "NVIDIA GeForce MX450", 16, 512, 1_199);
            Item computer13 = new Computer("/css/pictures/dell.jpg", 1, "Dell", "XPS", "Dell XPS 15", "A high-end laptop with a stunning 4K display",
                            4, 599, "Intel Core i9", "Intel HM470", "NVIDIA GeForce GTX 1650 Ti", 32, 1_000, 2_399);
            Item computer14 = new Computer("https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_4L6M3EAABB_ProductPicture.jpg", 1, "HP", "Spectre", "HP Spectre x360", "A premium 2-in-1 laptop with a sleek design",
                            4, 599, "Intel Core i7", "Intel HM470", "Intel Iris Xe Graphics", 16, 512, 1_499);
            Item computer15 = new Computer("https://www.bekredito.lt/wp-content/uploads/2022/07/lenovo-ideapad-5-14are05-pilka-r5-VL-15392375-BK.jpg16582709568056-400x400.jpg", 1, "Lenovo", "IdeaPad", "Lenovo IdeaPad 5", "A mid-range laptop with solid specs",
                            4, 599, "AMD Ryzen 7", "AMD B550", "NVIDIA GeForce MX450", 16, 512, 899);
            Item computer16 = new Computer("https://kainos-img.dgn.lt/photos2_25_57017815/asus-vivobook-s15-s533fa-bq009t-156-intel-i5-10210u-8gb-512gb-ssd-intel-uhd-windows-10-home.jpg", 1, "ASUS", "VivoBook", "ASUS VivoBook S15", "A budget-friendly laptop with a modern design",
                            4, 599, "Intel Core i5", "Intel HM470", "Intel UHD Graphics 620", 8, 256, 599);
            Item computer17 = new Computer("https://images.kaina24.lt/9/71/dell-latitude-9510.jpg", 1, "Dell", "Latitude", "Dell Latitude 9510", "A business laptop with long battery life",
                            4, 599, "Intel Core i7", "Intel vPro", "Intel UHD Graphics", 16, 512, 1_999);
            Item computer18 = new Computer("https://cdn.cs.1worldsync.com/99/9d/999dc6a0-df08-4122-bb2c-99658722df2c.jpg", 1, "HP", "EliteBook", "HP EliteBook 840 G8", "A business laptop with a sturdy design",
                            4, 599, "Intel Core i5", "Intel vPro", "Intel UHD Graphics", 16, 512, 1_199);
            Item computer19 = new Computer("https://assets.grandandtoy.com/graphics/400x400/c20/21/20213EE7-FCFF-451C-908D-733835CAE7A8.jpg", 1, "Lenovo", "ThinkBook", "Lenovo ThinkBook 13s", "A business laptop with a modern design",
                            4, 599, "Intel Core i5", "Intel vPro", "Intel UHD Graphics", 8, 256, 899);
            Item computer20 = new Computer("https://wecelltrade.com/wp-content/uploads/2023/01/Chromebook-Flip-C436.jpg", 1, "ASUS", "Chromebook", "ASUS Chromebook Flip C434", "A lightweight Chromebook with a premium look and feel",
                            4, 599, "Intel Core m3", "Intel Core m3", "Intel HD Graphics 615", 4, 64, 569);
            Item computer21 = new Computer("https://www.discorpshop.com/autoimg/3225917/400x400/ffffff/5550.jpg", 1, "Dell", "Precision", "Dell Precision 5550", "A high-end mobile workstation for professionals",
                4, 599, "Intel Core i7", "Intel Xeon", "NVIDIA Quadro T1000", 16, 512, 2_199);
            Item computer22 = new Computer("https://img.computerunivers.net/images/400x400/908437165E0D03798D664BAB83B692D2.jpg", 1, "HP", "ZBook", "HP ZBook Studio G8", "A mobile workstation for creatives and professionals",
                            4, 599, "Intel Core i7", "Intel Xeon", "NVIDIA GeForce RTX 3070", 32, 1_000, 3_499);
            Item computer23 = new Computer("https://aitnetas.lt/144296-medium_default/lenovo-thinkpad-x1-carbon-gen-10-black-paint-14-ips-wquxga-1920-x-1200-anti-glare-i7-1260p-16-gb-ssd-512-gb-intel-iris-xe-graphi.jpg", 1, "Lenovo", "ThinkPad", "Lenovo ThinkPad X1 Carbon", "A premium business laptop with a durable design",
                            4, 599, "Intel Core i7", "Intel vPro", "Intel UHD Graphics", 16, 1_000, 1_599);
            Item computer24 = new Computer("https://cdn.shopify.com/s/files/1/0228/7629/1136/products/04_15_Scar_L_400x.png?v=1643823634", 1, "ASUS", "ROG Strix", "ASUS ROG Strix Scar 15", "A high-end gaming laptop with a fast display",
                            4, 599, "Intel Core i9", "Intel HM470", "NVIDIA GeForce RTX 3080", 32, 1_000, 2_999);
            Item computer25 = new Computer("https://images.manokaina.lt/gHuuzm8zVhX3RCfJMAekotZ9PvY=/400x400/middle/https://www.skytech.lt/images/medium/8/2915808.png", 1, "Dell", "G Series", "Dell G5 15 SE", "A mid-range gaming laptop with an AMD CPU",
                            4, 599, "AMD Ryzen 7", "AMD B550", "AMD Radeon RX 5600M", 16, 512, 999);
            Item computer26 = new Computer("https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_3ZV24EA-ABU_ProductPicture.jpg", 1, "HP", "Omen", "HP Omen 15", "A mid-range gaming laptop with a fast display",
                            4, 599, "Intel Core i7", "Intel HM470", "NVIDIA GeForce RTX 2060", 16, 512, 1_199);
            Item computer27 = new Computer("https://www.bekredito.lt/wp-content/uploads/2022/08/lenovo-82jw00jbpb-legion-5-15ach-PG57330978BK.jpg16614606762097-400x400.jpg", 1, "Lenovo", "Legion", "Lenovo Legion 5", "A mid-range gaming laptop with a long battery life",
                            4, 599, "AMD Ryzen 7", "AMD B550", "NVIDIA GeForce GTX 1660 Ti", 16, 512, 1_099);
            Item computer28 = new Computer("https://www.discorpshop.com/autoimg/3014215/400x400/ffffff/fx506ih-hn190t-be.jpg", 1, "ASUS", "TUF Gaming", "ASUS TUF Gaming A15", "A budget-friendly gaming laptop with a sturdy design",
                            4, 599, "AMD Ryzen 5", "AMD B550", "NVIDIA GeForce GTX 1650", 8, 512, 799);
            Item computer29 = new Computer("https://img.computerunivers.net/images/400x400/908554789B1610355E9D40169247686A.jpg", 1, "Dell", "Alienware", "Dell Alienware m15 R6", "A high-end gaming laptop with a premium design",
                            4, 599, "Intel Core i9", "Intel HM470", "NVIDIA GeForce RTX 3080", 32, 1_000, 2_799);
            Item computer30 = new Computer("https://aitnetas.lt/144296-medium_default/lenovo-thinkpad-x1-carbon-gen-10-black-paint-14-ips-wquxga-1920-x-1200-anti-glare-i7-1260p-16-gb-ssd-512-gb-intel-iris-xe-graphi.jpg", 1, "Lenovo", "ThinkPad", "Lenovo ThinkPad X1 Carbon", "A premium ultrabook for business users",
                5, 599, "Intel Core i7", "Intel UHD Graphics", "Integrated", 16, 512, 1600);
            Item computer31 = new Computer("https://multimedia.bbycastatic.ca/multimedia/products/400x400/162/16271/16271527.jpg", 1, "Asus", "ROG", "Asus ROG Zephyrus G15", "A high-end gaming laptop with great performance",
                            4, 599, "AMD Ryzen 9", "NVIDIA GeForce RTX 3080", "AMD Radeon Graphics", 32, 1, 2000);
            Item computer32 = new Computer("https://static3.webx.pk/files/21500/Images/Thumbnails-Large/er0002-21500-722395-131221101044819.jpg", 1, "HP", "Pavilion", "HP Pavilion x360", "A versatile 2-in-1 laptop with a touchscreen display",
                            4, 599, "Intel Core i5", "Intel UHD Graphics", "Integrated", 8, 256, 800);
            Item computer33 = new Computer("https://img.computerunivers.net/images/400x400/90905238FC36E9663E844B51B02A44F4.jpg", 1, "Acer", "Nitro", "Acer Nitro 5", "An affordable gaming laptop with decent specs",
                            4, 599, "AMD Ryzen 5", "NVIDIA GeForce GTX 1650", "Integrated", 8, 512, 700);
            Item computer34 = new Computer("https://img.computerunivers.net/images/400x400/90906784A4F2CFE48B974144B8D7DE1D.jpg", 1, "Dell", "XPS", "Dell XPS 13", "A premium ultrabook with excellent build quality",
                            4, 599, "Intel Core i7", "Intel UHD Graphics", "Integrated", 16, 512, 1500);
            Item computer35 = new Computer("https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_4L6M3EAABB_ProductPicture.jpg", 1, "HP", "Spectre", "HP Spectre x360", "A stylish 2-in-1 laptop with a 4K display",
                            4, 599, "Intel Core i7", "Intel Iris Plus Graphics", "Integrated", 16, 512, 1800);
            Item computer36 = new Computer("https://mrlaptop.pk/wp-content/uploads/2020/10/6367799ld-1540-9360-280220014011.jpg", 1, "Lenovo", "Yoga", "Lenovo Yoga C940", "A high-end 2-in-1 laptop with great performance",
                            4, 599, "Intel Core i7", "Intel Iris Plus Graphics", "Integrated", 16, 512, 1700);
            Item computer37 = new Computer("https://kainos-img.dgn.lt/photos2_25_62424323/asus-zenbook-ux425ja-hm254t-14-fhd-ips-i5-1035g1-8gb-512ssd-w10.jpg", 1, "Asus", "ZenBook", "Asus ZenBook 14", "A sleek ultrabook with a 14-inch display",
                            4, 599, "Intel Core i7", "Intel Iris Plus Graphics", "Integrated", 16, 512, 1200);
            Item computer38 = new Computer("https://www.kilobaitas.lt//ImageHandler.ashx?ImageUrl=ItemImages%2FLocal%2FTdBaltic%2FTdBaltic_5EN50EAUUW_ProductPicture.jpg", 1, "HP", "Envy", "HP Envy 13", "A premium ultrabook with a long battery life",
                            4, 599, "Intel Core i7", "Intel Iris Plus Graphics", "Integrated", 16, 512, 1300);

            Item smartphone = new Smartphone("/css/pictures/iphone.jpg", 2, "Apple", "iPhone", "Apple iPhone 13", "The iPhone 13 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle.", 100, 699, "Hexa-core", 4, "A15 Bionic", 128);

            //items.Add(computer);
            //items.Add(computer1);
            //items.Add(computer2);
            //items.Add(computer3);
            //items.Add(computer4);
            //items.Add(computer5);
            //items.Add(computer6);
            //items.Add(computer7);
            //items.Add(computer8);
            //items.Add(computer9);
            //items.Add(computer10);
            //items.Add(computer11);
            //items.Add(computer12);
            //items.Add(computer13);
            //items.Add(computer14);
            //items.Add(computer15);
            //items.Add(computer16);
            //items.Add(computer17);
            //items.Add(computer18);
            //items.Add(computer19);
            //items.Add(computer20);
            //items.Add(computer21);
            //items.Add(computer22);
            //items.Add(computer23);
            //items.Add(computer24);
            //items.Add(computer25);
            //items.Add(computer26);
            //items.Add(computer27);
            //items.Add(computer28);
            //items.Add(computer29);
            //items.Add(computer30);
            //items.Add(computer31);
            //items.Add(computer32);
            //items.Add(computer33);
            //items.Add(computer34);
            //items.Add(computer35);
            //items.Add(computer36);
            //items.Add(computer37);
            //items.Add(computer38);
            //items.Add(smartphone);


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
            _logger = logger; ;
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
            List<Item> searchedItems = new List<Item>();
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

        public Item GetItemByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(name))
                {
                    return items[i];
                }
            
            }
            return null;
        }

        // Cart
        public Item GetItem(int id, string name)
        {
            if (name == null || id <= 0)
            {
                throw new ArgumentNullException(nameof(name));
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(name) && items[i].Id == id)
                {
                    return items[i];
                }
            }
            return null;
        }

        public IActionResult AddToCart(int id, string name)
        {
            if (name == null || id < 0)
            {
                return BadRequest("Item not found");
            }
            Item item = GetItem(id, name);
            if (item == null)
            {
                return BadRequest("Item not found");
            }

            UpdateCart(item);

            return Ok();
        }

        public void InitializeSession()
        {
            if (!HttpContext.Session.Keys.Contains("cart"))
            {
                HttpContext.Session.SetString("cart", cart.SerializeCart());
                return;
            }
            cart.DeserializeCart(HttpContext.Session.GetString("cart"));
        }

        public void UpdateCart(Item item)
        {
            InitializeSession();

            cart.DeserializeCart(HttpContext.Session.GetString("cart"));
            cart.Add(item, 1);
            HttpContext.Session.SetString("cart", cart.SerializeCart());
        }

        public IActionResult Cart()
        {
            InitializeSession();
            cart.DeserializeCart(HttpContext.Session.GetString("cart"));
            return View(cart);
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

        public IActionResult ChangeCartItemDetails(string productName, int amount)
        {
            if (amount <= 0) {
                amount = 1;
            }
            cart.DeserializeCart(HttpContext.Session.GetString("cart"));
            cart.Update(GetItemByName(productName), amount);
            HttpContext.Session.SetString("cart", cart.SerializeCart());
            return RedirectToAction("Cart");
        }

        public IActionResult DeleteFromCart(string productName)
        {
            cart.DeserializeCart(HttpContext.Session.GetString("cart"));
            cart.Remove(GetItemByName(productName));
            HttpContext.Session.SetString("cart", cart.SerializeCart());
            return RedirectToAction("Cart");
        }



    }
}
