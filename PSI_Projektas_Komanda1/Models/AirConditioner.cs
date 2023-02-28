using System;

public class AirConditioner : Item
{
	public double MaxArea { get; set; }
	public int MinTemp { get; set; } // Celsius
	public int MaxTemp { get; set; } // Celsius

	public AirConditioner(int id, string brand, string model, string name, string desciption, int amount,
        double maxArea, int minTemp, int maxtemp) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.MaxArea = maxArea;
        this.MaxTemp = maxtemp;
        this.MinTemp = minTemp;
	}
	
	public AirConditioner() { }
}
