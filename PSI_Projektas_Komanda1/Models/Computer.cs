using System;
[Serializable]
public class Computer : Item
{
	public string Processor { get; set; }
	public string Motherboard { get; set; }
	public string GPU { get; set; }
	public int Ram { get; set; } //In GB
	public int Memory { get; set; } //In GB
	public int PowerSupplyWattage { get; set; } // Watts


	public Computer(string pic,int id, string brand, string model, string name, string desciption, int amount, decimal price,
		string processor, string motherboard, string gpu, int ram, int memory, int powerSupplyWattage) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Processor = processor;
		this.Motherboard = motherboard;
		this.GPU = gpu;
		this.Ram = ram;
		this.Memory = memory;
		this.PowerSupplyWattage= powerSupplyWattage;
	}

    public Computer(string[] parts) : base(parts)
    {
        try
        {
            string processor = parts[8];
            string motherboard = parts[9];
            string gpu = parts[10];
            int ram = int.Parse(parts[11]);
            int memory = int.Parse(parts[12]);
            int powerSupplyWattage = int.Parse(parts[13]);
            this.Processor = processor;
            this.Motherboard = motherboard;
            this.GPU = gpu;
            this.Ram = ram;
            this.Memory = memory;
            this.PowerSupplyWattage = powerSupplyWattage;

        }
        catch
        {
            throw new Exception("Computer parsing went wrong");
        }
    }

    public Computer() { }

    public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		list.Add("Procesorius: " + Processor);
		list.Add("Pagrindinė plokštė: " + Motherboard);
		list.Add("GPU: " + GPU);
		list.Add("Ram: " + Ram + " GB");
		list.Add("Atmintis: " + Memory + " GB");
		list.Add("Power supply: " + PowerSupplyWattage + " W");
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
		list.Add("Kaina: " + Price);
        return list;
    }

	public override string ToString()
	{
		return "Computer;" + base.ToString() + string.Format(";{0};{1};{2};{3};{4};{5}", this.Processor, 
            this.Motherboard, this.GPU, this.Ram, this.Memory, this.PowerSupplyWattage);
    }
}
