namespace PSI_Projektas_Komanda1.Repositories
{
    public class DryerRepo
    {
        public static List<Item> ReadDryers()
        {
            var query = $@"SELECT * FROM `dryers`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Dryer>(drc, (dre, t) =>
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

		public static Item FindDryer(int id)
		{
			var query = $@"SELECT * FROM `dryers` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Dryer>(drc, (dre, t) =>
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

		public static void InsertDryer(Dryer dryer)
		{
			var query = $@"INSERT INTO `dryers` 
            (pic, brand, model, name, description, amount, price, volume ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?volume)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", dryer.Picture);
				args.Add("?brand", dryer.Brand);
				args.Add("?model", dryer.Model);
				args.Add("?name", dryer.Name);
				args.Add("?description", dryer.Description);
				args.Add("?amount", dryer.Amount);
				args.Add("?price", dryer.Price);
				args.Add("?volume", dryer.Volume);
			});

			dryer.Id = id;
			ItemRepo.InsertItem(dryer);
		}
	}
}
