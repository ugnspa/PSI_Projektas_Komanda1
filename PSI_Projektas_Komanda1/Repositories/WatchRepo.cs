namespace PSI_Projektas_Komanda1.Repositories
{
    public class WatchRepo
    {
        public static List<Item> ReadWatches()
        {
            var query = $@"SELECT * FROM `watches`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Watch>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Smart = dre.From<bool>("smart");
                t.DaysCharged = dre.From<int>("days_charged");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindWatch(int id)
		{
			var query = $@"SELECT * FROM `watches` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Watch>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Smart = dre.From<bool>("smart");
				t.DaysCharged = dre.From<int>("days_charged");
			});

			return result;
		}

		public static void InsertWatch(Watch watch)
		{
			var query = $@"INSERT INTO `watches` 
            (pic, brand, model, name, description, amount, price, smart, ?days_charged ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?smart, ?days_charged)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", watch.Picture);
				args.Add("?brand", watch.Brand);
				args.Add("?model", watch.Model);
				args.Add("?name", watch.Name);
				args.Add("?description", watch.Description);
				args.Add("?amount", watch.Amount);
				args.Add("?price", watch.Price);
				args.Add("?smart", watch.Smart);
				args.Add("?days_charged", watch.DaysCharged);
			});

			watch.Id = id;
			ItemRepo.InsertItem(watch);
		}

        public static void DeleteWatch(int itemId)
        {
            var query = $@"DELETE FROM `watches` WHERE id = ?id";

            Sql.Delete(query, args =>
            {
                args.Add("?id", itemId);
            });
        }
    }
}
