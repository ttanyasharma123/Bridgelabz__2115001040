using System;
using System.Collections.Generic;

// Abstract class Product
abstract class Product
{
    protected int productId;
    protected string name;
    protected double price;

    public Product(int id, string name, double price)
    {
        this.productId = id;
        this.name = name;
        this.price = price;
    }

    public abstract double CalculateDiscount();

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Product ID: {productId}, Name: {name}, Price: {price:C}");
    }

    public double GetPrice()
    {
        return price;
    }
}

// Interface ITaxable
interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

// Electronics class
class Electronics : Product, ITaxable
{
    public Electronics(int id, string name, double price) : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.20; // 20% discount
    }

    public double CalculateTax()
    {
        return price * 0.50; // 50% tax
    }

    public string GetTaxDetails()
    {
        return "Electronics are taxed at 15%.";
    }
}

class Clothing : Product
{
    public Clothing(int id, string name, double price) : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.10; // 10% discount
    }
}

// Groceries class
class Groceries : Product, ITaxable
{
    public Groceries(int id, string name, double price) : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.05; // 5% discount
    }

    public double CalculateTax()
    {
        return price * 0.05; // 5% tax
    }

    public string GetTaxDetails()
    {
        return "Groceries are taxed at 5%.";
    }
}

// Main program
class Program
{
    static void CalculateFinalPrice(List<Product> products)
    {
        foreach (var product in products)
        {
            double discount = product.CalculateDiscount();
            double tax = (product is ITaxable taxableProduct) ? taxableProduct.CalculateTax() : 0;
            double finalPrice = product.GetPrice() + tax - discount;

            product.DisplayDetails();
            Console.WriteLine($"Discount: {discount:C}, Tax: {tax:C}, Final Price: {finalPrice:C}\n");
        }
    }

    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Electronics(101, "Laptop", 50000),
            new Clothing(102, "Jeans", 1000),
            new Groceries(103, "Choclate", 50)
        };

        CalculateFinalPrice(products);
    }
}
