using System;

public class Watch : Item
{
	public bool Smart { get; set; }
	public int DaysCharged { get; set; } // Ammount of days without charging
	public Watch(string pic, int id, string brand, string model, string name, string desciption, int amount, 
		decimal price, bool smart, int daysCharged) :
		base(pic, id, brand, model, name, desciption, amount, price)
	{
		this.Smart = smart;
		this.DaysCharged = daysCharged;
	}

    public Watch(string[] parts) : base(parts)
    {
        try
        {
            this.Smart = bool.Parse(parts[8]);
            this.DaysCharged = int.Parse(parts[9]);
        }
        catch
        {
            throw new Exception("Watch parsing went wrong");
        }
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
        list.Add("Kaina: " + Price);
        return list;
    }

    public override List<string> GetProperties()
    {
        List<string> list = new List<string>();
        list.Add("Nuotrauka");
        list.Add("Id");
        list.Add("Gamintojas");
        list.Add("Modelis");
        list.Add("Pavadinimas");
        list.Add("Aprašymas");
        list.Add("Kiekis");
        list.Add("Kaina");
        list.Add("Smart");
        list.Add("DaysCharged");
        return list;
    }

    public override string ToString()
    {
        return "Watch;" + base.ToString() + string.Format(";{0};{1}", this.Smart, this.DaysCharged);
    }
}
