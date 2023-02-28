using System;

public class Stove : Item
{
	public int Count { get; set; }
	public bool Electric { get; set; }
	public Stove(int id, string brand, string model, string name, string desciption, int amount, 
		int count, bool electric) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Count = count;
		this.Electric = electric;
	}
	
	public Stove() { }
}
