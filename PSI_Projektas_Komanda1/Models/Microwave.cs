using System;

public class Microwave : Item
{
	public double Volume { get; set; }
	public Microwave(string pic,int id, string brand, string model, string name, string desciption, int amount, double volume, decimal price) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Volume = volume;
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
}
