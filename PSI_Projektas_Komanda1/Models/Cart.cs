using MySqlX.XDevAPI.Common;
using System.Text.RegularExpressions;

namespace PSI_Projektas_Komanda1.Models
{
	public class Cart
	{
		public Dictionary<Item, int> Items { get; set; }

		public Cart() 
		{
            Items = new Dictionary<Item, int>();
		}

		public void Add(Item item, int amount)
		{
			if(Items.ContainsKey(item))
			{
                Items[item] += amount;
			}
			else
			{
				Items.Add(item, amount);
			}
		}

		public void Update(Item item, int amount)
		{
			if(Items.ContainsKey(item))
			{
				Items[item] = amount;
			}			
		}	

		public void Remove(Item item)
		{
			if(!Items.ContainsKey(item)) 
				return;

			Items.Remove(item);
		}

		public Item Get(int index)
		{
			return Items.ElementAt(index).Key;
		}

		public int GetAmount(int index)
		{
            return Items.ElementAt(index).Value;
        }

        public int Size()
		{
			return Items.Count;
		}
		public void RemoveAll() 
		{
			Items.Clear();
		}

        public decimal Price()
        {
            decimal result = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                result += Items.ElementAt(i).Key.Price * Items.ElementAt(i).Value;
            }

            return result;
        }

        /// <summary>
        /// Method for creating custom serialization used to store cart contents in session
        /// </summary>
        /// <returns>A string containing data about all items in the cart</returns>
        public string SerializeCart()
		{
			string result = "";
			for(int i = 0; i < Items.Count; i++)
			{
				result += string.Format("{0}={1}#", Items.ElementAt(i).Key.ToString(), Items.ElementAt(i).Value);
			}

            return result;
		}


		/// <summary>
		/// Methods which takes custom serialized data produced with SerializeCart() method and adds it into the cart
		/// </summary>
		/// <param name="serializedValue">Serialized data string</param>
        public void DeserializeCart(string serializedValue)
        {
			Items.Clear();
			string[] parts = serializedValue.Split('#', StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
			{
                string[] parts2 = part.Split('=', StringSplitOptions.RemoveEmptyEntries);
				string[] itemParts = parts2[0].Split(';', StringSplitOptions.RemoveEmptyEntries);

				Item item = ParseItem(itemParts);
				int amount = int.Parse(parts2[1]);
				this.Add(item, amount);
			}
        }

		
		private Item ParseItem(string[] parts)
		{
			switch(parts[0])
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
