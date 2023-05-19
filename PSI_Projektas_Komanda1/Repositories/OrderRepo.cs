using PSI_Projektas_Komanda1.Models;

namespace PSI_Projektas_Komanda1.Repositories
{
	public class OrderRepo
	{
		public static List<Order> ReadOrders()
		{
			var query = $@"SELECT orders.*, u.id as userID, u.Name as name, u.Surname as surname, 
						u.Email as email, u.Username as username, u.Password as password FROM orders
							LEFT JOIN users u ON u.id=fk_userID";

			var drc = Sql.Query(query);

			var result = Sql.MapAll<Order>(drc, (dre, t) =>
			{
				t.ID = dre.From<int>("id");
				t.User = new User();
				t.User.ID= dre.From<int>("userID");
				t.User.Name= dre.From<string>("name");
				t.User.SurName = dre.From<string>("surname");
				t.User.Email = dre.From<string>("email");
				t.User.UserName = dre.From<string>("username");
				t.User.Password = dre.From<string>("password");
				t.Adress = dre.From<string>("address");
				t.Price = dre.From<decimal>("price");
			});

			

			foreach(var item in result)
			{
				item.items = ReadOrderedItems(item);
			}
			foreach (var item in result)
			{
				Console.WriteLine(string.Format("{0} {1} {2} {3}", item.ID, item.Price, item.User.Name, item.items.Count));
			}
			return result;
		}

		public static Dictionary<Item, int> ReadOrderedItems(Order order)
		{
			var query = "SELECT amount, i.id as id, i.type as type, i.fk_id as fk_id FROM item_order LEFT JOIN items i on i.id=fk_itemID WHERE fk_orderID=?orderID";

			var drc = Sql.Query(query, args =>
			{
				args.Add("?orderID", order.ID);
			});

			var items = Sql.MapAll<ItemID>(drc, (dre, t) => { 
				t.ID= dre.From<int>("id");
				t.Type = dre.From<string>("type");
				t.fkID = dre.From<int>("fk_id");
				t.Amount = dre.From<int>("amount");
			});

			return GenerateItemList(items);
		}

		public static Dictionary<Item, int> GenerateItemList(List<ItemID> items)
		{
			Dictionary<Item, int> dict = new Dictionary<Item, int>();
			//List<Item> result = new List<Item>();
			foreach (ItemID item in items)
			{
				switch (item.Type)
				{
					case ("AirConditioner"):
						dict.Add(AirConditionerRepo.FindAirConditioner(item.fkID), item.Amount);
						break;
					case ("Camera"):
						dict.Add(CameraRepo.FindCamera(item.fkID), item.Amount);
						break;
					case ("Computer"):
						dict.Add(ComputerRepo.FindComputer(item.fkID), item.Amount);
						break;
					case ("Dishwasher"):
						dict.Add(DishwasherRepo.FindDiswasher(item.fkID), item.Amount);
						break;
					case ("Dryer"):
						dict.Add(DryerRepo.FindDryer(item.fkID), item.Amount);
						break;
					case ("HeatingSystem"):
						dict.Add(HeatingSystemRepo.FindHeatingSystem(item.fkID), item.Amount);
						break;
					case ("Microwave"):
						dict.Add(MicrowaveRepo.FindMicrowave(item.fkID), item.Amount);
						break;
					case ("Oven"):
						dict.Add(OvenRepo.FindOven(item.fkID), item.Amount);
						break;
					case ("Smartphone"):
						dict.Add(SmartphoneRepo.FindSmartphone(item.fkID), item.Amount);
						break;
					case ("Stove"):
						dict.Add(StoveRepo.FindStove(item.fkID), item.Amount);
						break;
					case ("TV"):
						dict.Add(TVRepo.FindTV(item.fkID), item.Amount);
						break;
					case ("Vacuum"):
						dict.Add(VacuumRepo.FindVacuum(item.fkID), item.Amount);
						break;
					case ("WashingMachine"):
						dict.Add(WashingMachineRepo.FindWashingMachine(item.fkID), item.Amount);
						break;
					case ("Watch"):
						dict.Add(WatchRepo.FindWatch(item.fkID), item.Amount);
						break;
					default:
						throw new Exception(string.Format("Type not supported at id: {0}", item.ID));

				}
			}
			return dict;
		}

		public static void InsertOrder(Order order)
		{
			var query = "INSERT INTO orders (fk_userID, address, price) VALUES (?userID, ?adress,?price)";
			var drc = Sql.Query(query, args =>
			{
				args.Add("?userID", order.User.ID);
				args.Add("adress", order.Adress);
				args.Add("?price", order.Price);
			});

			int ID = (int)Sql.Insert(query, args =>
			{
				args.Add("?userID", order.User.ID);
				args.Add("adress", order.Adress);
				args.Add("?price", order.Price);
			});
			order.ID = ID;
			InsertOrderedItems(order);
		}

		public static void InsertOrderedItems(Order order)
		{
			foreach(Item item in order.items.Keys)
			{
				int amount = order.items[item];
				int uniqueID = ItemRepo.GetItemId(item.Id, item.GetType().ToString());
				InsertOrderItem(order.ID, uniqueID, amount);
			}
		}

		public static void InsertOrderItem(int orderID, int itemID, int amount)
		{
			var query = $@"INSERT INTO item_order (fk_itemID, fk_orderID, amount) VALUES (?itemID, ?orderID, ?amount)";

			Sql.Insert(query, args =>
			{
				args.Add("?itemID", itemID);
				args.Add("?orderID", orderID);
				args.Add("?amount", amount);
			});
		}
	}
}
