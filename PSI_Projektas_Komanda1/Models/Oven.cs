using System;

public class Oven : Item
{
	public double Volume { get; set; }
	public string Type { get; set; }
	public Oven(int id, string brand, string model, string name, string desciption, int amount, double volume, string type) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
		this.Type = type;
	}
	
	public Oven() { }
}
