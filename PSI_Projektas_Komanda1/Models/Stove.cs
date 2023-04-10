using System;

public class Stove : Item
{
	public int Count { get; set; }
	public bool Electric { get; set; }
	public Stove(string pic,int id, string brand, string model, string name, string desciption, int amount, 
		decimal price, int count, bool electric) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Count = count;
		this.Electric = electric;
	}

    public Stove(string[] parts) : base(parts)
    {
        try
        {
            this.Count = int.Parse(parts[8]);
            this.Electric = bool.Parse(parts[9]);
        }
        catch
        {
            throw new Exception("Stove parsing went wrong");
        }
    }

    public Stove() { }

	public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
		if (Electric)
			list.Add("Elektrinė: taip");
		else
			list.Add("Elektrinė: ne");
        list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        list.Add("Kaina: " + Price);
        return list;
    }

    public override string ToString()
    {
        return "Stove;" + base.ToString() + string.Format(";{0};{1}", this.Count, this.Electric);
    }
}
