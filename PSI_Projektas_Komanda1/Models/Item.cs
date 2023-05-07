using Mysqlx.Crud;
using System;
using System.Xml.Linq;

public abstract class Item
{
    public string Picture { get; set; }
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
	public string Name { get; set; }
    public string Description { get; set; }
	public int Amount { get; set; }
    public decimal Price { get; set; }

    public Item(string pic,int id, string brand, string model, string name, string desciption, int amount, decimal price)
    {
        this.Picture = pic;
        this.Id = id;
        this.Brand = brand;
        this.Model = model;
        this.Name = name;
        this.Description = desciption;
        this.Amount = amount;
        this.Price = price;
    }

    public Item(string[] parts)
    {
        try
        {
            this.Picture = parts[0];
            this.Id = int.Parse(parts[1]);
            this.Brand = parts[2];
            this.Model = parts[3];
            this.Name = parts[4];
            this.Description = parts[5];
            this.Amount = int.Parse(parts[6]);
            this.Price = decimal.Parse(parts[7]);
        }
        catch
        {
            throw new Exception("Item parsing went wrong");
        }
    }

    public Item()
	{
	}

    abstract public List<string> Print();

    abstract public List<string> GetProperties();



    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        Item other = obj as Item;
        if (this.Id == other.Id && this.Model.Equals(other.Model) && 
            this.Brand.Equals(other.Brand) && this.Price == other.Price)
            return true;
        else
            return false;
    }

    public override int GetHashCode()
    {
        int hash = 13;

        hash = hash * 23 + this.Id.GetHashCode();
        hash = hash * 23 + this.Model.GetHashCode();
        hash = hash * 23 + this.Brand.GetHashCode();
        hash = hash * 23 + this.Price.GetHashCode();

        return hash;
    }

    public bool CompareTo(object? obj)
    {
        return this.Equals(obj);
    }
    public override string ToString()
    {
        return string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", this.Picture, this.Id, this.Brand, this.Model, this.Name, this.Description, this.Amount, this.Price);
    }
}
