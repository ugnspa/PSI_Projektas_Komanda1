namespace PSI_Projektas_Komanda1.Repositories
{
    public class OvenRepo
    {
        public static List<Item> ReadOvens()
        {
            var query = $@"SELECT * FROM `ovens`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Oven>(drc, (dre, t) =>
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
                t.Type= dre.From<string>("type");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindOven(int id)
		{
			var query = $@"SELECT * FROM `ovens` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Oven>(drc, (dre, t) =>
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
				t.Type = dre.From<string>("type");
			});

			return result;
		}

		public static void InsertOven(Oven oven)
		{
			var query = $@"INSERT INTO `ovens` 
            (pic, brand, model, name, description, amount, price, volume, type ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?volume, ?type)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", oven.Picture);
				args.Add("?brand", oven.Brand);
				args.Add("?model", oven.Model);
				args.Add("?name", oven.Name);
				args.Add("?description", oven.Description);
				args.Add("?amount", oven.Amount);
				args.Add("?price", oven.Price);
				args.Add("?volume", oven.Volume);
				args.Add("?type", oven.Type);
			});

			oven.Id = id;
			ItemRepo.InsertItem(oven);
		}
	}
}
