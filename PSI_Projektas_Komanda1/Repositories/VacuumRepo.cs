namespace PSI_Projektas_Komanda1.Repositories
{
    public class VacuumRepo
    {
        public static List<Item> ReadVacuums()
        {
            var query = $@"SELECT * FROM `vacuums`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Vacuum>(drc, (dre, t) =>
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

		public static Item FindVacuum(int id)
		{
			var query = $@"SELECT * FROM `vacuums` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Vacuum>(drc, (dre, t) =>
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

		public static void InsertVacuum(Vacuum vacuum)
		{
			var query = $@"INSERT INTO `vacuums` 
            (pic, brand, model, name, description, amount, price, volume ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?volume)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", vacuum.Picture);
				args.Add("?brand", vacuum.Brand);
				args.Add("?model", vacuum.Model);
				args.Add("?name", vacuum.Name);
				args.Add("?description", vacuum.Description);
				args.Add("?amount", vacuum.Amount);
				args.Add("?price", vacuum.Price);
				args.Add("?volume", vacuum.Volume);
			});

			vacuum.Id = id;
			ItemRepo.InsertItem(vacuum);
		}
	}
}
