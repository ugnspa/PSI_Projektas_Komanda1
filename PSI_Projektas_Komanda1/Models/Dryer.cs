using System;

public class Dryer
{
	public double Volume { get; set; }
	public Dryer(int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
	}
	
	public Dryer() { }
}
