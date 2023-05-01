namespace PSI_Projektas_Komanda1.Repositories
{
    public class StoveRepo
    {
        public static List<Item> ReadStoves()
        {
            var query = $@"SELECT * FROM `stoves`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Stove>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Count = dre.From<int>("count");
                t.Electric = dre.From<bool>("electric");
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
