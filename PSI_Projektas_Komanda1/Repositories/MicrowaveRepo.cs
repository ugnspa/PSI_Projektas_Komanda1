namespace PSI_Projektas_Komanda1.Repositories
{
    public class MicrowaveRepo
    {
        public static List<Item> ReadMicrowaves()
        {
            var query = $@"SELECT * FROM `microwaves`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Microwave>(drc, (dre, t) =>
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

		public static Item FindMicrowave(int id)
		{
			var query = $@"SELECT * FROM `microwaves` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Microwave>(drc, (dre, t) =>
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

		public static void InsertMicrowave(Microwave microwave)
		{
			var query = $@"INSERT INTO `microwaves` 
            (pic, brand, model, name, description, amount, price, volume ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?volume)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", microwave.Picture);
				args.Add("?brand", microwave.Brand);
				args.Add("?model", microwave.Model);
				args.Add("?name", microwave.Name);
				args.Add("?description", microwave.Description);
				args.Add("?amount", microwave.Amount);
				args.Add("?price", microwave.Price);
				args.Add("?volume", microwave.Volume);
			});

			microwave.Id = id;
			ItemRepo.InsertItem(microwave);
		}
	}
}
