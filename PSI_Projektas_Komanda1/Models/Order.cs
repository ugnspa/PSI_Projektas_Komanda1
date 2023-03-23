using System;
[Serializable]
public class Order
    {
        Dictionary<Item, int> items;

        public Order()
        {
            this.items = new Dictionary<Item, int>();
        }
        
        public Dictionary<Item, int> get() { return this.items; }


        public void Add(Item item)
        {
            if (!items.ContainsKey(item))
            {
                items.Add(item, 1);
            }
            else
            {
                items[item]++;
            }
        }

        public void Remove(Item item)
        {
            if(items.ContainsKey(item))
            {
                items[item]--;
                if (items[item] == 0)
                {
                    items.Remove(item);
                }
            }
        }

        public bool Contains(Item item)
        {
            return items.ContainsKey(item);
        }

        public double TotalPrice()
        {
        double price = 0;
        Item[] keys = items.Keys.ToArray();
        for (int i = 0; i < keys.Length; i++)
        {
            Item item = keys[i];
            price += (double)item.Price * items[item];
        }
        return price;
        }
    public double ItemPrice(Item item)
     {
        return (double)item.Price * items[item];
     }
    public int count()
    {
        return items.Count;
    }

    }


