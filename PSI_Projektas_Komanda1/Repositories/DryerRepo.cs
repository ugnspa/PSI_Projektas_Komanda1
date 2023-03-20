namespace PSI_Projektas_Komanda1.Repositories
{
    public class DryerRepo
    {
        public static List<Item> ReadDryers()
        {
            var query = $@"SELECT * FROM `dryers`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Dryer>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id_Dryer");
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
