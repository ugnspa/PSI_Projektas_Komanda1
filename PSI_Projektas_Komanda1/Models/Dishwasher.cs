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
}
