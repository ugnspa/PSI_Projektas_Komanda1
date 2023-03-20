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
                t.Id = dre.From<int>("id_Camera");
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
    }
}
