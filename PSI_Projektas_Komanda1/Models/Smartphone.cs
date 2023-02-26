using System;

public class Smartphone : Item
{
	public string Processor { get; set; }
	public int Ram { get; set; } // In GB
	public string GPU { get; set; }
	public int Memory { get; set; } //In GB	
	public Smartphone(int id, string brand, string model, string name, string desciption, 
		int amount, string processor, int ram, string gpu, int memory) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Processor = processor;
		this.Ram = ram;
		this.GPU = gpu;
		this.Memory = memory;
	}

	public Smartphone() : base () { }
}
