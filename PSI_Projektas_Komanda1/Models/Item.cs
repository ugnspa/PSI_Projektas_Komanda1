using System;
[Serializable]
public abstract class Item
{
    public string Picture { get; set; }
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
	public string Name { get; set; }
    public string Description { get; set; }
	public int Amount { get; set; }
    public decimal Price { get; set; }

    public Item(string pic,int id, string brand, string model, string name, string desciption, int amount, decimal price)
    {
        this.Picture = pic;
        this.Id = id;
        this.Brand = brand;
        this.Model = model;
        this.Name = name;
        this.Description = desciption;
        this.Amount = amount;
        this.Price = price;
    }

    public Item()
	{
	}

  abstract public List<string> Print();
}
