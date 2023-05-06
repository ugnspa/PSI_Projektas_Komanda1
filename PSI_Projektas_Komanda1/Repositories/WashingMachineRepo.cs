namespace PSI_Projektas_Komanda1.Repositories
{
    public class WashingMachineRepo
    {
        public static List<Item> ReadWashingMachines()
        {
            var query = $@"SELECT * FROM `washingmachines`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<WashingMashine>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Volume = dre.From<double>("volume");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindWashingMachine(int id)
		{
			var query = $@"SELECT * FROM `washingmachines` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<WashingMashine>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Volume = dre.From<double>("volume");
			});

			return result;
		}

		public static void InsertWashingMashine(WashingMashine washingMashine)
		{
			var query = $@"INSERT INTO `washingmachines` 
            (pic, brand, model, name, description, amount, price, volume ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?volume)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", washingMashine.Picture);
				args.Add("?brand", washingMashine.Brand);
				args.Add("?model", washingMashine.Model);
				args.Add("?name", washingMashine.Name);
				args.Add("?description", washingMashine.Description);
				args.Add("?amount", washingMashine.Amount);
				args.Add("?price", washingMashine.Price);
				args.Add("?volume", washingMashine.Volume);
			});

			washingMashine.Id = id;
			ItemRepo.InsertItem(washingMashine);
		}
	}
}
