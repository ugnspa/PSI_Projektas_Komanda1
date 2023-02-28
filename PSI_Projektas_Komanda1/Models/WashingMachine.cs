Washi System;

public class HeatingSystem : Item
{
	public double Volume { get; set; }
	public HeatingSystem(int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
	}
	
	public HeatingSystem() { }
}
