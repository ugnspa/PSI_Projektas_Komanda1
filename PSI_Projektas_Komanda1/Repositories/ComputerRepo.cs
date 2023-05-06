namespace PSI_Projektas_Komanda1.Repositories
{
    public class ComputerRepo
    {
        public static List<Item> ReadComputers()
        {
            var query = $@"SELECT * FROM `computers`";
            var drc = Sql.Query(query);

            var result = Sql.MapAll<Computer>(drc, (dre, t) =>
            {
                t.Picture = dre.From<string>("pic");
                t.Id = dre.From<int>("id");
                t.Brand = dre.From<string>("brand");
                t.Model = dre.From<string>("model");
                t.Name = dre.From<string>("name");
                t.Description = dre.From<string>("description");
                t.Amount = dre.From<int>("amount");
                t.Price = dre.From<decimal>("price");
                t.Processor = dre.From<string>("processor");
                t.Motherboard = dre.From<string>("motherboard");
                t.GPU = dre.From<string>("gpu");
                t.Ram = dre.From<int>("ram");
                t.Memory = dre.From<int>("memory");
                t.PowerSupplyWattage = dre.From<int>("power_supply_wattage");
            });

            List<Item> items = new List<Item>();
            foreach (Item item in result)
            {
                items.Add(item);
            }
            return items;
        }
        public static List<Item> SelectFirstTen()
        {
			var query = $@"SELECT * FROM `computers` Limit 10";
			var drc = Sql.Query(query);

			var result = Sql.MapAll<Computer>(drc, (dre, t) =>
			{
				t.Picture = dre.From<string>("pic");
				t.Id = dre.From<int>("id");
				t.Brand = dre.From<string>("brand");
				t.Model = dre.From<string>("model");
				t.Name = dre.From<string>("name");
				t.Description = dre.From<string>("description");
				t.Amount = dre.From<int>("amount");
				t.Price = dre.From<decimal>("price");
				t.Processor = dre.From<string>("processor");
				t.Motherboard = dre.From<string>("motherboard");
				t.GPU = dre.From<string>("gpu");
				t.Ram = dre.From<int>("ram");
				t.Memory = dre.From<int>("memory");
				t.PowerSupplyWattage = dre.From<int>("power_supply_wattage");
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
