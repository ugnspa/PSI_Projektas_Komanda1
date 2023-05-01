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
    }
}
