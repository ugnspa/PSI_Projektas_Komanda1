using System;

public class Watch : Item
{
	public static bool Smart { get; set; }
	public static int DaysCharged { get; set; } // Ammount of days without charging
	public Watch(int id, string brand, string model, string name, string desciption, int amount, bool smart, int daysCharged) : 
		base(id, brand, model, name, desciption, amount)
	{
		this.Smart = smart;
		this.DaysCharger = daysCharged;
	}
	
	public Watch() { }
}
