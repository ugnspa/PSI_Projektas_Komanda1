using PSI_Projektas_Komanda1.Models;

namespace PSI_Projektas_Komanda1.Repositories
{
	public class ItemRepo
	{
		public static List<Item> ReadItems()
		{
			var query = $@"SELECT * FROM `items`";
			var drc = Sql.Query(query);

			var result = Sql.MapAll<ItemID>(drc, (dre, t) => {
				t.ID = dre.From<int>("id");
				t.Type = dre.From<string>("type");
				t.fkID = dre.From<int>("fk_id");

			});
			GenerateItemList(result);
		}

		public static List<Item> GenerateItemList(List<ItemID> items)
		{
			List<Item> result = new List<Item>();
			foreach(ItemID item in items)
			{
				switch(item.Type)
				{
					case ("AirConditioner"):
						result.Add(AirConditionerRepo.FindAirConditioner(item.fkID));
						break;
					case ("Camera"):
						result.Add(CameraRepo.FindCamera(item.fkID));
						break;
					case ("Computer"):
						result.Add(ComputerRepo.FindComputer(item.fkID));
						break;
					case ("Dishwasher"):
						result.Add(DishwasherRepo.FindDiswasher(item.fkID));
						break;
					case ("Dryer"):
						result.Add(DryerRepo.FindDryer(item.fkID));
						break;
					case ("HeatingSystem"):
						result.Add(HeatingSystemRepo.FindHeatingSystem(item.fkID));
						break;
					case ("Microwave"):
						result.Add(MicrowaveRepo.FindMicrowave(item.fkID));
						break;
					case ("Oven"):
						result.Add(OvenRepo.FindOven(item.fkID));
						break;
					case ("Smartphone"):
						result.Add(SmartphoneRepo.FindSmartphone(item.fkID));
						break;
					case ("Stove"):
						result.Add(StoveRepo.FindStove(item.fkID));
						break;
					case ("TV"):
						result.Add(TVRepo.FindTV(item.fkID));
						break;
					case ("Vacuum"):
						result.Add(VacuumRepo.FindVacuum(item.fkID));
						break;
					case ("WashingMachine"):
						result.Add(WashingMachineRepo.FindWashingMachine(item.fkID));
						break;
					case ("Watch"):
						result.Add(WatchRepo.FindWatch(item.fkID));
						break;
					default:
						throw new Exception(string.Format("Type not supported at id: {0}", item.ID));

				}
			}
			return result;
		}

		public static void InsertItem(Item item)
		{
			var query = $@"INSERT INTO items (type, fk_id) VALUES (?type, ?fk_id)";

			Sql.Insert(query, args =>
			{
				args.Add("?type", item.GetType());
				args.Add("?fk_id", item.Id);
			});
		}
	}
}
