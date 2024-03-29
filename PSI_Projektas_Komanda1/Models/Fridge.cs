﻿using System;

public class Fridge : Item
{
	public bool Freezer { get; set; }
	public double Volume { get; set; }
	public double FreezerVolume { get; set; } = 0;
	public Fridge(string pic,int id, string brand, string model, string name, string desciption, int amount, 
        decimal price, bool freezer, double volume, double freezerVolume = 0) : 
		base(pic, id, brand, model, name, desciption, amount, price)
	{
		this.Freezer = freezer;
		this.Volume = volume;
		this.FreezerVolume = freezerVolume;
	}

    public Fridge(string[] parts) : base(parts)
    {
        try
        {
            this.Freezer = bool.Parse(parts[8]);
            this.Volume = double.Parse(parts[9]);
            this.FreezerVolume= double.Parse(parts[10]);
        }
        catch
        {
            throw new Exception("Fridge parsing went wrong");
        }
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
        list.Add("Šaldiklis");
        list.Add("Tūris");
        list.Add("Šaldiklio tūris");
        return list;
    }

    public override string ToString()
    {
        return "Fridge;" + base.ToString() + string.Format(";{0};{1};{2}",this.Freezer, this.Volume, this.FreezerVolume);
    }
}
