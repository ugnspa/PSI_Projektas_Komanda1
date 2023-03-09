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
}
