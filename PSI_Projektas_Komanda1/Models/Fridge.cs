using System;

public class Fridge : Item
{
	public bool Freezer { get; set; }
	public double Volume { get; set; }
	public double FreezerVolume { get; set; } = 0;
	public Fridge(string pic,int id, string brand, string model, string name, string desciption, int amount, bool freezer, double volume, double freezerVolume = 0) : 
		base(pic, id, brand, model, name, desciption, amount)
	{
		this.Freezer = freezer;
		this.Volume = volume;
		this.FreezerVolume = freezerVolume;
	}
	
	public Fridge() { }

  public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		if (Freezer == true)
			list.Add("Šaldiklis: yra");
		else list.Add("Šaldiklis: nėra");
		list.Add("Tūris: " + Volume);
		if (Freezer == true)
			list.Add("Šaldiklio tūris: " + FreezerVolume);
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        return list;
    }
}
