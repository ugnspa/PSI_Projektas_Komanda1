namespace PSI_Projektas_Komanda1.Repositories
{
    public class SmartphoneRepo
    {
        public static List<Item> ReadSmartphones()
        {
            var query = $@"SELECT * FROM `smartphones`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Smartphone>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Processor = dre.From<string>("processor");
                t.Ram = dre.From<int>("ram");
                t.GPU = dre.From<string>("gpu");
                t.Memory = dre.From<int>("memory");
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
			var query = $@"SELECT * FROM `smartphones` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Smartphone>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Processor = dre.From<string>("processor");
				t.Ram = dre.From<int>("ram");
				t.GPU = dre.From<string>("gpu");
				t.Memory = dre.From<int>("memory");
			});

			return result;
		}
	}
}
