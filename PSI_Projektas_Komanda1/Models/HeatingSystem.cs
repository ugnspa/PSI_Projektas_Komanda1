using System;

public class HeatingSystem : Item
{
	public double MaxArea { get; set; }
	public HeatingSystem(string pic,int id, string brand, string model, string name, string desciption, int amount, double maxArea) : 
		base(pic,id, brand, model, name, desciption, amount)
	{
		this.MaxArea = maxArea;
	}
	
	public HeatingSystem() { }

  public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
        list.Add("Didžiausias plotas: " + MaxArea);
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        return list;
    }
}
