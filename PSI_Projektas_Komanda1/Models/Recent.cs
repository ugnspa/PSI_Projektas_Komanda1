using Org.BouncyCastle.Utilities;

namespace PSI_Projektas_Komanda1.Models
{
    public class Recent
    {
        List<Item> items { get; set; }
        int max = 5;

        public Recent()
        {
            items = new List<Item>();
        }

        public void Add(Item item)
        {
            List<Item> newItems = new List<Item>();
            newItems.Add(item);

            if (Contains(item.Name))
            {
                // Copy all items except the existing item to the new list
                for (int i = 0; i < items.Count && newItems.Count < max; i++)
                {
                    if (!items[i].Name.Equals(item.Name))
                    {
                        newItems.Add(items[i]);
                    }
                }
            }
            else
            {
                // Copy all items to the new list
                for (int i = 0; i < items.Count && newItems.Count < max; i++)
                {
                    newItems.Add(items[i]);
                }
            }

            items = newItems;
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }
        public Item GetItem(int index)
        {
            return items[index];
        }
        public bool Contains(string name)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public int Count()
        {
            return items.Count;
        }

        /// <summary>
        /// Method for creating custom serialization used to store cart contents in session
        /// </summary>
        /// <returns>A string containing data about all items in the cart</returns>
        public string SerializeRecent()
        {
            string result = "";
            for (int i = 0; i < items.Count; i++)
            {
                result += string.Format("{0}#", items[i].ToString());
            }

            return result;
        }


        /// <summary>
        /// Methods which takes custom serialized data produced with SerializeCart() method and adds it into the cart
        /// </summary>
        /// <param name="serializedValue">Serialized data string</param>
        public void DeserializeRecent(string serializedValue)
        {
            items.Clear();
            string[] parts = serializedValue.Split('#', StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string[] itemParts = part.Split(';', StringSplitOptions.RemoveEmptyEntries);

                Item item = ParseItem(itemParts);
                items.Add(item);
            }
        }


        private Item ParseItem(string[] parts)
        {
            switch (parts[0])
            {
                case "AirConditioner":
                    return new AirConditioner(parts.Skip(1).ToArray());
                case "Camera":
                    return new Camera(parts.Skip(1).ToArray());
                case "Computer":
                    return new Computer(parts.Skip(1).ToArray());
                case "Dishwasher":
                    return new Dishwasher(parts.Skip(1).ToArray());
                case "Dryer":
                    return new Dryer(parts.Skip(1).ToArray());
                case "Fridge":
                    return new Fridge(parts.Skip(1).ToArray());
                case "HeatingSystem":
                    return new HeatingSystem(parts.Skip(1).ToArray());
                case "Microwave":
                    return new Microwave(parts.Skip(1).ToArray());
                case "Oven":
                    return new Oven(parts.Skip(1).ToArray());
                case "Smartphone":
                    return new Smartphone(parts.Skip(1).ToArray());
                case "Stove":
                    return new Stove(parts.Skip(1).ToArray());
                case "TV":
                    return new TV(parts.Skip(1).ToArray());
                case "Vacuum":
                    return new Vacuum(parts.Skip(1).ToArray());
                case "WashingMashine":
                    return new WashingMashine(parts.Skip(1).ToArray());
                case "Watch":
                    return new Watch(parts.Skip(1).ToArray());
                default:
                    return null;
            }
        }

    }
}
