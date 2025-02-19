using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
    private Dictionary<string, double> productPrices = new Dictionary<string, double>();  // Store product prices
    private LinkedList<KeyValuePair<string, double>> orderedProducts = new LinkedList<KeyValuePair<string, double>>();  // Maintain order
    private SortedDictionary<double, List<string>> sortedProducts = new SortedDictionary<double, List<string>>();  // Sort by price

    // Method to add a product to the cart
    public void AddProduct(string productName, double price)
    {
        if (!productPrices.ContainsKey(productName))
        {
            productPrices[productName] = price;

            // Maintain order using LinkedList (acts like LinkedHashMap)
            orderedProducts.AddLast(new KeyValuePair<string, double>(productName, price));

            // Maintain sorted order
            if (!sortedProducts.ContainsKey(price))
            {
                sortedProducts[price] = new List<string>();
            }
            sortedProducts[price].Add(productName);
        }
        else
        {
            Console.WriteLine(string.Format("Product '{0}' already exists in the cart.", productName));
        }
    }

    // Method to display all products with their prices
    public void DisplayProducts()
    {
        Console.WriteLine("\nProducts in Cart:");
        foreach (var entry in productPrices)
        {
            Console.WriteLine(string.Format("{0}: ${1:F2}", entry.Key, entry.Value));
        }
    }

    // Method to display products in order of addition
    public void DisplayOrderedProducts()
    {
        Console.WriteLine("\nProducts in Order of Addition:");
        foreach (var entry in orderedProducts)
        {
            Console.WriteLine(string.Format("{0}: ${1:F2}", entry.Key, entry.Value));
        }
    }

    // Method to display products sorted by price
    public void DisplaySortedProducts()
    {
        Console.WriteLine("\nProducts Sorted by Price:");
        foreach (var entry in sortedProducts)
        {
            foreach (var product in entry.Value)
            {
                Console.WriteLine(string.Format("{0}: ${1:F2}", product, entry.Key));
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();

        // Add sample products
        cart.AddProduct("Laptop", 1000.00);
        cart.AddProduct("Phone", 500.00);
        cart.AddProduct("Tablet", 750.00);
        cart.AddProduct("Headphones", 200.00);
        cart.AddProduct("Mouse", 50.00);

        // Display products
        cart.DisplayProducts();
        cart.DisplayOrderedProducts();
        cart.DisplaySortedProducts();
    }
}
