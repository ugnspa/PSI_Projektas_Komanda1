using System;

public class Dishwasher : Item
{
	public double Volume { get; set; }
	public Dishwasher(string pic, int id, string brand, string model, string name, string desciption, int amount, 
		decimal price, double volume) : 
		base(pic, id, brand, model, name, desciption, amount, price)
	{
		this.Volume = volume;
	}

    public Dishwasher(string[] parts) : base(parts)
    {
        try
        {
            this.Volume = double.Parse(parts[8]);
        }
        catch
        {
            throw new Exception("Dishwasher parsing went wrong");
        }
    }

    public Dishwasher() { }
  
	public override List<string> Print()
	{
		List<string> list = new List<string>();
		list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		list.Add("Id: " + Id.ToString());
		list.Add("Tūris: " + Volume.ToString());
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
        return list;
    }

    public override string ToString()
    {
        return "Dishwasher;" + base.ToString() + string.Format(";{0}", this.Volume);
    }
}
