namespace PSI_Projektas_Komanda1.order
{
    public class Order
    {
        Dictionary<Item, int> items;

        public Order()
        {
            this.items = new Dictionary<Item, int>();
        }

        public void Add(Item item, int amount)
        {
            items.Add(item, amount);
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }

        public bool Contains(Item item)
        {
            return items.ContainsKey(item);
        }








    }
}
