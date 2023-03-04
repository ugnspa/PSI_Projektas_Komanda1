using System;

public abstract class Item
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
	public string Name { get; set; }
    public string Description { get; set; }
	public int Amount { get; set; }

    public Item(int id, string brand, string model, string name, string desciption, int amount)
    {
        this.Id = id;
        this.Brand = brand;
        this.Model = model;
        this.Name = name;
        this.Description = desciption;
        this.Amount = amount;   
    }

    public Item()
	{
	}

  abstract public List<string> Print();
}
