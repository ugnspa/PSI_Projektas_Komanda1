namespace PSI_Projektas_Komanda1.Repositories
{
    public class FridgeRepo
    {
        public static List<Item> ReadFridges()
        {
            var query = $@"SELECT * FROM `dryers`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Fridge>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id_Dryer");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Freezer = dre.From<bool>("freezer");
                t.Volume = dre.From<double>("volume");
                t.FreezerVolume = dre.From<double>("freezer_volume");
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
