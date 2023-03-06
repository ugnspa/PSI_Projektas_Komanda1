using System;

public class TV : Item
{
	public double Diagonal { get; set; }
	public TV(string pic,int id, string brand, string model, string name, string desciption, int amount, double diagonal) : 
		base(pic,id, brand, model, name, desciption, amount)
	{
		this.Diagonal = diagonal;
	}
	
	public TV() { }

  public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
        list.Add("Įstrižainė: " + Diagonal);
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        return list;
    }
}
