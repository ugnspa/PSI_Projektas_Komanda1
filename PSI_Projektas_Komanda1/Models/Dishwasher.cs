using System;

public class Dishwasher : Item
{
	public double Volume { get; set; }
	public Dishwasher(int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
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
		return list;
    }

    /*public override string ToString()
    {
        return string.Format("Prekės id: {0}  Gamintojas: {1} /n Modelis: {2} /n Pavadinimas: {3} /n Aprašymas: {4} /n Tūris: {5}",
            Id, Brand, Model, Name, Description, Volume);
    }*/
}
