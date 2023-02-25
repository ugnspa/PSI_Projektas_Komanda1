using System;

public class Fridge
{
	public bool Freezer { get; set; }
	public double Volume { get; set; }
	public double FreezerVolume { get; set; } = 0;
	public Fridge(int id, string brand, string model, string name, string desciption, int amount, bool freezer, double volume, double freezerVolume = 0) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Freezer = freezer;
		this.Volume = volume;
		this.FreezerVolume = freezerVolume;
	}
	
	public Fridge() { }
}
