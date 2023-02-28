using System;

public class Vacuum : Item
{
	public double Volume { get; set; }
	public Vacuum(int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
	}
	
	public Vacuum() { }
}
