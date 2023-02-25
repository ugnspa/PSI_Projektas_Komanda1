using System;

public class TV
{
	public double Diagonal { get; set; }
	public TV(int id, string brand, string model, string name, string desciption, int amount, double diagonal) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Diagonal = diagonal;
	}
	
	public TV() { }
}
