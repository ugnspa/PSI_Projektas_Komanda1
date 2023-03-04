using System;

public class Oven : Item
{
	public double Volume { get; set; }
	public string Type { get; set; }
	public Oven(int id, string brand, string model, string name, string desciption, int amount, double volume, string type) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
		this.Type = type;
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
        return list;
    }
}
