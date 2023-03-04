using System;

public class Camera : Item
{
	public int MegaPixels { get; set; }
	public Camera(int id, string brand, string model, string name, string desciption, int amount, int megaPixels) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.MegaPixels = megaPixels;

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
        return list;
    }
}
