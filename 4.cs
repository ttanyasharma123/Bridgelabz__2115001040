using System;

class Product
{
    // Static variable shared by all products (Discount in percentage)
    public static double Discount = 10.0;

    // Readonly variable for Product ID (Cannot be modified after assignment)
    public readonly int ProductID;

    // Instance variables
    public string ProductName { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; private set; }

    // Constructor using 'this' to initialize variables
    public Product(int productId, string productName, double price, int quantity)
    {
        this.ProductID = productId;
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
    }

    // Static method to update discount percentage
    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    // Method to display product details, using 'is' operator
    public void DisplayProductDetails()
    {
        if (this is Product)
        {
            Console.WriteLine("Product ID: " + ProductID);
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Price: $" + Price);
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Discount: " + Discount + "%");
            Console.WriteLine("Final Price after Discount: $" + CalculateFinalPrice());
            Console.WriteLine("--------------------------");
        }
    }

    // Method to calculate final price after applying discount
    public double CalculateFinalPrice()
    {
        return Price - (Price * Discount / 100);
    }
}

// Main class to test the Product class
class Program
{
    static void Main()
    {
        // Creating Product objects
        Product product1 = new Product(1, "Laptop", 50000, 1);
        Product product2 = new Product(2, "Smartphone", 20000, 2);

        // Displaying product details
        product1.DisplayProductDetails();
        product2.DisplayProductDetails();

        // Updating the discount
        Console.WriteLine("Updating Discount to 15%...");
        Product.UpdateDiscount(15);

        // Displaying updated product details
        product1.DisplayProductDetails();
        product2.DisplayProductDetails();
    }
}
