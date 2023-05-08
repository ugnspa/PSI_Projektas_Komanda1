namespace PSI_Projektas_Komanda1.Repositories
{
    public class AirConditionerRepo
    {
        public static List<Item> ReadAirConditioners()
        {
            var query = $@"SELECT * FROM `airconditioners`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<AirConditioner>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name= dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.MaxArea = dre.From<double>("max_area");
                t.MinTemp = dre.From<int>("min_temp");
                t.MaxTemp = dre.From<int>("min_temp");
            });

            List<Item> items = new List<Item>();
            foreach(Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindAirConditioner(int id)
		{
			var query = $@"SELECT * FROM `airconditioners` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<AirConditioner>(drc, (dre, t) =>
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
				t.MinTemp = dre.From<int>("min_temp");
				t.MaxTemp = dre.From<int>("max_temp");
			});

			return result;
		}

		public static void InsertAirConditioner(AirConditioner airConditioner)
        {
            var query = $@"INSERT INTO `airconditioners` 
            (pic, brand, model, name, description, amount, price, max_area, min_temp, max_temp ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?max_area, ?min_temp, ?max_temp)";

            int id = (int)Sql.Insert(query, args =>
            {
                args.Add("?pic", airConditioner.Picture);
				args.Add("?brand", airConditioner.Brand);
				args.Add("?model", airConditioner.Model);
				args.Add("?name", airConditioner.Name);
				args.Add("?description", airConditioner.Description);
				args.Add("?amount", airConditioner.Amount);
				args.Add("?price", airConditioner.Price);
				args.Add("?max_area", airConditioner.MaxArea);
				args.Add("?min_temp", airConditioner.MinTemp);
				args.Add("?max_temp", airConditioner.MaxTemp);
			});

            airConditioner.Id = id;
            ItemRepo.InsertItem(airConditioner);
        }

        public static void DeleteAirConditioner(int itemId)
        {
            var query = $@"DELETE FROM `airconditioners` WHERE id = ?id";

            Sql.Delete(query, args =>
            {
                args.Add("?id", itemId);
            });
        }
    }
}
