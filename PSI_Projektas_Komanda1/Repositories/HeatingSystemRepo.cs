namespace PSI_Projektas_Komanda1.Repositories
{
    public class HeatingSystemRepo
    {
        public static List<Item> ReadHeatingSystems()
        {
            var query = $@"SELECT * FROM `heatingsystems`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<HeatingSystem>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.MaxArea = dre.From<double>("max_area");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindHeatingSystem(int id)
		{
			var query = $@"SELECT * FROM `heatingsystems` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<HeatingSystem>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.MaxArea = dre.From<double>("max_area");
			});

			return result;
		}
	}
}
