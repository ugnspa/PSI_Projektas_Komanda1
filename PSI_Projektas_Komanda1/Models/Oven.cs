using System;

public class Oven : Item
{
	public double Volume { get; set; }
	public string Type { get; set; }
	public Oven(string pic,int id, string brand, string model, string name, string desciption, int amount, double volume, string type, decimal price) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Volume = volume;
		this.Type = type;
	}

    public Oven(string[] parts) : base(parts)
    {
        try
        {
            this.Volume = double.Parse(parts[8]);
            this.Type = parts[9];
        }
        catch
        {
            throw new Exception("Oven parsing went wrong");
        }
    }
    public Oven() { }

	public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		list.Add("Tūris: " + Volume);
		list.Add("Tipas: " + Type);
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        list.Add("Kaina: " + Price);
        return list;
    }

    public override List<string> GetProperties()
    {
        List<string> list = new List<string>();
        list.Add("Nuotrauka");
        list.Add("Id");
        list.Add("Gamintojas");
        list.Add("Modelis");
        list.Add("Pavadinimas");
        list.Add("Aprašymas");
        list.Add("Kiekis");
        list.Add("Kaina");
        list.Add("Tūris");
        list.Add("Tipas");
        return list;
    }

    public override string ToString()
    {
        return "Oven;" + base.ToString() + string.Format(";{0};{1}", this.Volume, this.Type);
    }
}
