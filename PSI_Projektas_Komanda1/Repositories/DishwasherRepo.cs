namespace PSI_Projektas_Komanda1.Repositories
{
    public class DishwasherRepo
    {
        public static List<Item> ReadDiswashers()
        {
            var query = $@"SELECT * FROM `dishwashers`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Dishwasher>(drc, (dre, t) =>
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
    }
}
