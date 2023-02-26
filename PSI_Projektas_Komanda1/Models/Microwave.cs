using System;

public class Microwave
{
	public double Volume { get; set; }
	public Microwave(int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
	}
	
	public Microwave() { }
}
