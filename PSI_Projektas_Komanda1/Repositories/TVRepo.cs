namespace PSI_Projektas_Komanda1.Repositories
{
    public class TVRepo
    {
        public static List<Item> ReadTVs()
        {
            var query = $@"SELECT * FROM `tvs`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<TV>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id_TV");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Diagonal = dre.From<double>("diagonal");
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
