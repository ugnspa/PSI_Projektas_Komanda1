namespace PSI_Projektas_Komanda1.Repositories
{
    public class DishwasherRepo
    {
        public static List<Item> ReadDiswashers()
        {
            var query = $@"SELECT * FROM `dishwashers`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Dishwasher>(drc, (dre, t) =>
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

		public static Item FindDiswasher(int id)
		{
			var query = $@"SELECT * FROM `dishwashers` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Dishwasher>(drc, (dre, t) =>
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

		public static void InsertDishwasher(Dishwasher dishwasher)
		{
			var query = $@"INSERT INTO `dishwashers` 
            (pic, brand, model, name, description, amount, price, volume ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?volume)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", dishwasher.Picture);
				args.Add("?brand", dishwasher.Brand);
				args.Add("?model", dishwasher.Model);
				args.Add("?name", dishwasher.Name);
				args.Add("?description", dishwasher.Description);
				args.Add("?amount", dishwasher.Amount);
				args.Add("?price", dishwasher.Price);
				args.Add("?volume", dishwasher.Volume);
			});

			dishwasher.Id = id;
			ItemRepo.InsertItem(dishwasher);
		}
	}
}
