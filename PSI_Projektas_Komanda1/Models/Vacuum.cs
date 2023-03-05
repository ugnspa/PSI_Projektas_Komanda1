using System;

public class Vacuum : Item
{
	public double Volume { get; set; }
	public Vacuum(string pic,int id, string brand, string model, string name, string desciption, int amount, double volume) : 
		base(pic,id, brand, model, name, desciption, amount)
	{
		this.Volume = volume;
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
        return list;
    }

}
