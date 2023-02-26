using System;

public class Computer
{
	public string Processor { get; set; }
	public string Motherboard { get; set; }
	public string GPU { get; set; }
	public int Ram { get; set; } //In GB
	public int Memory { get; set; } //In GB
	public int PowerSupplyWattage { get; set; } // Watts


	public Computer(int id, string brand, string model, string name, string desciption, int amount, 
		string processor, string motherboard, string gpu, int ram, int memory, int powerSupplyWattage) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Processor = processor;
		this.Motherboard = motherboard;
		this.GPU = gpu;
		this.Ram = ram;
		this.Memory = memory;
		this.PowerSupplyWattage= powerSupplyWattage;
	}
	
	public Computer() { }
}
