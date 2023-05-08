namespace PSI_Projektas_Komanda1.Repositories
{
    public class TVRepo
    {
        public static List<Item> ReadTVs()
        {
            var query = $@"SELECT * FROM `tvs`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<TV>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Diagonal = dre.From<double>("diagonal");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindTV(int id)
		{
			var query = $@"SELECT * FROM `tvs` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<TV>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Diagonal = dre.From<double>("diagonal");
			});

			return result;
		}
		public static void InsertTV(TV tv)
		{
			var query = $@"INSERT INTO `tvs` 
            (pic, brand, model, name, description, amount, price, diagonal ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?diagonal)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", tv.Picture);
				args.Add("?brand", tv.Brand);
				args.Add("?model", tv.Model);
				args.Add("?name", tv.Name);
				args.Add("?description", tv.Description);
				args.Add("?amount", tv.Amount);
				args.Add("?price", tv.Price);
				args.Add("?diagonal", tv.Diagonal);
			});

			tv.Id = id;
			ItemRepo.InsertItem(tv);
		}

        public static void DeleteTV(int itemId)
        {
            var query = $@"DELETE FROM `tvs` WHERE id = ?id";

            Sql.Delete(query, args =>
            {
                args.Add("?id", itemId);
            });
        }
    }	
}
