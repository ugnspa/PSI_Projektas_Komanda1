using System;

public class AirConditioner : Item
{
	public double MaxArea { get; set; }
	public int MinTemp { get; set; } // Celsius
	public int MaxTemp { get; set; } // Celsius

	public AirConditioner(string pic,int id, string brand, string model, string name, string desciption, int amount,
        double maxArea, int minTemp, int maxtemp) : 
		base(pic,id, brand, model, name, desciption, amount)
	{
		this.MaxArea = maxArea;
        this.MaxTemp = maxtemp;
        this.MinTemp = minTemp;
	}
	
	public AirConditioner() { }

  public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
        list.Add("Didžiausias plotas: " + MaxArea.ToString());
        list.Add("Mažiausia temperatūra: " + MinTemp.ToString() + " ℃");
		list.Add("Didžiausia temperatūra: " + MinTemp.ToString() + " ℃");
		list.Add("Id: " + Id.ToString());
        list.Add("Kiekis: " + Amount.ToString());
        list.Add("Aprašymas: " + Description);
        return list;
    }
}
