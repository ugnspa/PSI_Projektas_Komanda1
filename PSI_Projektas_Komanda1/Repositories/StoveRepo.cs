namespace PSI_Projektas_Komanda1.Repositories
{
    public class StoveRepo
    {
        public static List<Item> ReadStoves()
        {
            var query = $@"SELECT * FROM `stoves`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Stove>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Count = dre.From<int>("count");
                t.Electric = dre.From<bool>("electric");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindStove(int id)
		{
			var query = $@"SELECT * FROM `stoves` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Stove>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Count = dre.From<int>("count");
				t.Electric = dre.From<bool>("electric");
			});

			return result;
		}

		public static void InsertStove(Stove stove)
		{
			var query = $@"INSERT INTO `stoves` 
            (pic, brand, model, name, description, amount, price, count, electric ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?count, ?electric)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", stove.Picture);
				args.Add("?brand", stove.Brand);
				args.Add("?model", stove.Model);
				args.Add("?name", stove.Name);
				args.Add("?description", stove.Description);
				args.Add("?amount", stove.Amount);
				args.Add("?price", stove.Price);
				args.Add("?count", stove.Count);
				args.Add("?electric", stove.Electric);
			});

			stove.Id = id;
			ItemRepo.InsertItem(stove);
		}

        public static void DeleteStove(int itemId)
        {
            var query = $@"DELETE FROM `stoves` WHERE id = ?id";

            Sql.Delete(query, args =>
            {
                args.Add("?id", itemId);
            });
        }
    }
}
