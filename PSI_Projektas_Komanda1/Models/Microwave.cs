using System;

public class Microwave : Item
{
	public double Volume { get; set; }
	public Microwave(string pic,int id, string brand, string model, string name, string desciption, int amount, double volume, decimal price) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Volume = volume;
	}

    public Microwave(string[] parts) : base(parts)
    {
        try
        {
            this.Volume = double.Parse(parts[8]);
        }
        catch
        {
            throw new Exception("Microwave parsing went wrong");
        }
    }

    public Microwave() { }

    public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
        list.Add("Tūris: " + Volume.ToString());
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        list.Add("Kaina: " + Price);
        return list;
    }

    public override string ToString()
    {
        return "Microwave;" + base.ToString() + string.Format(";{0}", this.Volume);
    }
}
