namespace PSI_Projektas_Komanda1.Repositories
{
    public class FridgeRepo
    {
        public static List<Item> ReadFridges()
        {
            var query = $@"SELECT * FROM `fridges`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Fridge>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Freezer = dre.From<bool>("freezer");
                t.Volume = dre.From<double>("volume");
                t.FreezerVolume = dre.From<double>("freezer_volume");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindFridge(int id)
		{
			var query = $@"SELECT * FROM `fridges` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Fridge>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Freezer = dre.From<bool>("freezer");
				t.Volume = dre.From<double>("volume");
				t.FreezerVolume = dre.From<double>("freezer_volume");
			});

			return result;
		}

		public static void InsertFridge(Fridge fridge)
		{
			var query = $@"INSERT INTO `fridges` 
            (pic, brand, model, name, description, amount, price, freezer, volume, freezer_volume ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?freezer, ?volume, ?freezer_volume)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", fridge.Picture);
				args.Add("?brand", fridge.Brand);
				args.Add("?model", fridge.Model);
				args.Add("?name", fridge.Name);
				args.Add("?description", fridge.Description);
				args.Add("?amount", fridge.Amount);
				args.Add("?price", fridge.Price);
				args.Add("?freezer", fridge.Freezer);
				args.Add("?volume", fridge.Volume);
				args.Add("?volume", fridge.Volume);
			});

			fridge.Id = id;
			ItemRepo.InsertItem(fridge);
		}

        public static void DeleteFridge(int itemId)
        {
            var query = $@"DELETE FROM `fridges` WHERE id = ?id";

            Sql.Delete(query, args =>
            {
                args.Add("?id", itemId);
            });
        }
    }
}
