using System;

public class Dishwasher : Item
{
	public double Volume { get; set; }
	public Dishwasher(int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
	}
	
	public Dishwasher() { }
}
