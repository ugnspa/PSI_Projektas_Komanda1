using System;

public class Camera : Item
{
	public int MegaPixels { get; set; }
	public Camera(string pic,int id, string brand, string model, string name, string desciption, int amount,
        decimal price, int megaPixels) : 
		base(pic,id, brand, model, name, desciption, amount, price)
	{
		this.MegaPixels = megaPixels;

    }
	
    public Camera(string[] parts) : base(parts)
    {
        try
        {
            this.MegaPixels = int.Parse(parts[8]);
        }
        catch
        {
            throw new Exception("Camera parsing went wrong");
        }
    }
	public Camera() { }

    public override List<string> Print()
    {
        List<string> list = new List<string>();
        list.Add("Gamintojas: " + Brand);
        list.Add("Modelis: " + Model);
        list.Add("Megapixels: " + MegaPixels);
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
        list.Add("Megapixeliai");
        return list;
    }

    public override string ToString()
    {
        return "Camera;" + base.ToString() + string.Format(";{0}", this.MegaPixels);
    }
}
