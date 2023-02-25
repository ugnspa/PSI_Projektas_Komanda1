using System;

public class HeatingSystem
{
	public double MaxArea { get; set; }
	public HeatingSystem(int id, string brand, string model, string name, string desciption, int amount, double maxArea) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.MaxArea = maxArea;
	}
	
	public HeatingSystem() { }
}
