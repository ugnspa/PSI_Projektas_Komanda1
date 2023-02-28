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
}
