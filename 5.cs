using System;
using System.Collections.Generic;

// Abstract class FoodItem
abstract class FoodItem
{
    protected string itemName;
    protected double price;
    protected int quantity;

    public FoodItem(string itemName, double price, int quantity)
    {
        this.itemName = itemName;
        this.price = price;
        this.quantity = quantity;
    }

    public abstract double CalculateTotalPrice();

    public virtual void GetItemDetails()
    {
        Console.WriteLine($"Item: {itemName}, Price: {price:C}, Quantity: {quantity}");
    }
}

// Interface IDiscountable
interface IDiscountable
{
    double ApplyDiscount(double percentage);
    string GetDiscountDetails();
}

// VegItem class
class VegItem : FoodItem, IDiscountable
{
    public VegItem(string itemName, double price, int quantity) : base(itemName, price, quantity) { }

    public override double CalculateTotalPrice()
    {
        return price * quantity; // No additional charge for veg items
    }

    public double ApplyDiscount(double percentage)
    {
        return CalculateTotalPrice() * (1 - percentage / 100);
    }

    public string GetDiscountDetails()
    {
        return "Veg items have seasonal discounts available.";
    }
}

// NonVegItem class
class NonVegItem : FoodItem, IDiscountable
{
    private double additionalCharge = 20.0; // Extra charge for non-veg items

    public NonVegItem(string itemName, double price, int quantity) : base(itemName, price, quantity) { }

    public override double CalculateTotalPrice()
    {
        return (price * quantity) + additionalCharge;
    }

    public double ApplyDiscount(double percentage)
    {
        return CalculateTotalPrice() * (1 - percentage / 100);
    }

    public string GetDiscountDetails()
    {
        return "Non-veg items have a flat 10% discount on weekends.";
    }
}

// Main program
class Program
{
    static void ProcessFoodItems(List<FoodItem> foodItems)
    {
        foreach (var item in foodItems)
        {
            item.GetItemDetails();
            Console.WriteLine($"Total Price: {item.CalculateTotalPrice():C}\n");
        }
    }

    static void Main()
    {
        List<FoodItem> foodItems = new List<FoodItem>
        {
            new VegItem("Paneer Butter Masala", 250, 2),
            new NonVegItem(" Biryani", 350, 1)
        };

        ProcessFoodItems(foodItems);
    }
}
