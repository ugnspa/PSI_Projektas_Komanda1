using System;

public class Watch : Item
{
	public bool Smart { get; set; }
	public int DaysCharged { get; set; } // Ammount of days without charging
	public Watch(int id, string brand, string model, string name, string desciption, int amount, bool smart, int daysCharged) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Smart = smart;
		this.DaysCharged = daysCharged;
	}
	
	public Watch() { }

    public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		if (Smart) list.Add("Smart: taip");
		else list.Add("Smart: ne");
		list.Add("Gali būti nekratas " + DaysCharged + " dienų");
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        return list;
    }
}
