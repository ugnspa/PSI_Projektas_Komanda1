namespace PSI_Projektas_Komanda1.Repositories
{
    public class CameraRepo
    {
        public static List<Item> ReadCameras()
        {
            var query = $@"SELECT * FROM `cameras`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Camera>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.MegaPixels = dre.From<int>("mega_pixels");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }

		public static Item FindCamera(int id)
		{
			var query = $@"SELECT * FROM `cameras` WHERE id = ?id";
			var drc =
				Sql.Query(query, args => {
					args.Add("?id", id);
				});

			var result = Sql.MapOne<Camera>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.MegaPixels = dre.From<int>("mega_pixels");
			});

			return result;
		}

		public static void InsertCamera(Camera camera)
		{
			var query = $@"INSERT INTO `cameras` 
            (pic, brand, model, name, description, amount, price, mega_pixels ) VALUES 
            (?pic, ?brand, ?model, ?name, ?description, ?amount, ?price, ?mega_pixels)";

			int id = (int)Sql.Insert(query, args =>
			{
				args.Add("?pic", camera.Picture);
				args.Add("?brand", camera.Brand);
				args.Add("?model", camera.Model);
				args.Add("?name", camera.Name);
				args.Add("?description", camera.Description);
				args.Add("?amount", camera.Amount);
				args.Add("?price", camera.Price);
				args.Add("?mega_pixels", camera.MegaPixels);
			});

			camera.Id = id;
			ItemRepo.InsertItem(camera);
		}
	}
}
