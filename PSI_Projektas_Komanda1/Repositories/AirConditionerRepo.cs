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
    }
}
