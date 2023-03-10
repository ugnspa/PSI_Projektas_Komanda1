using System;

public class Smartphone : Item
{
	public string Processor { get; set; }
	public int Ram { get; set; } // In GB
	public string GPU { get; set; }
	public int Memory { get; set; } //In GB	
	public Smartphone(string pic,int id, string brand, string model, string name, string desciption, 
		int amount, decimal price, string processor, int ram, string gpu, int memory) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Processor = processor;
		this.Ram = ram;
		this.GPU = gpu;
		this.Memory = memory;
	}

	public Smartphone() : base () { }

  public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		list.Add("Procesorius: " + Processor);
		list.Add("GPU: " + GPU);
		list.Add("Ram: " + Ram + " GB");
		list.Add("Atmintis: " + Memory + " GB");
		list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        list.Add("Kaina: " + Price);
        return list;
    }
}
