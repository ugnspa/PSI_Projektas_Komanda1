using System;

public class Vacuum : Item
{
	public double Volume { get; set; }
	public Vacuum(string pic, int id, string brand, string model, string name, string desciption, int amount, 
        decimal price, double volume) : 
        base(pic, id, brand, model, name, desciption, amount, price)
	{
		this.Volume = volume;
	}

    public Vacuum(string[] parts) : base(parts)
    {
        try
        {
            this.Volume = double.Parse(parts[8]);
        }
        catch
        {
            throw new Exception("Vacuum parsing went wrong");
        }
    }
    public Vacuum() { }
  
    public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
        list.Add("Tūris: " + Volume);
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        list.Add("Kaina: " + Price);
        return list;
    }

    public override string ToString()
    {
        return "Vacuum;" + base.ToString() + string.Format(";{0}", this.Volume);
    }

}
