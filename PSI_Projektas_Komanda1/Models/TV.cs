using System;

public class TV : Item
{
	public double Diagonal { get; set; }
	public TV(string pic,int id, string brand, string model, string name, string desciption, int amount, decimal price, double diagonal) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.Diagonal = diagonal;
	}

    public TV(string[] parts) : base(parts)
    {
        try
        {
            this.Diagonal = double.Parse(parts[8]);
        }
        catch
        {
            throw new Exception("TV parsing went wrong");
        }
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
        list.Add("Kaina: " + Price);
        return list;
    }

    public override string ToString()
    {
        return "TV;" + base.ToString() + string.Format(";{0}", this.Diagonal);
    }
}
