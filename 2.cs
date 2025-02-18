using System;
using System.Collections.Generic;

// Step 1: Define Product Categories
abstract class ProductCategory
{
    public string CategoryName { get; set; }
}

class BookCategory : ProductCategory
{
    public BookCategory() { CategoryName = "Books"; }
}

class ClothingCategory : ProductCategory
{
    public ClothingCategory() { CategoryName = "Clothing"; }
}

// Step 2: Define a Generic Product Class
class Product<T> where T : ProductCategory
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public T Category { get; set; }

    public Product(int id, string name, double price, T category)
    {
        ID = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine($"[{Category.CategoryName}] ID: {ID}, Name: {Name}, Price: ${Price:F2}");
    }
}

// Step 3: Implement a Generic Product Catalog
class Catalog<T> where T : Product<ProductCategory>
{
    private List<T> products = new List<T>();

    public void AddProduct(T product)
    {
        products.Add(product);
        Console.WriteLine($"{product.Name} added to the catalog.");
    }

    public void RemoveProduct(int id)
    {
        var product = products.Find(p => p.ID == id);
        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine($"{product.Name} removed from the catalog.");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    public void DisplayProducts()
    {
        Console.WriteLine("\nProduct Catalog:");
        foreach (var product in products)
        {
            product.Display();
        }
    }
}

// Step 4: Implement a Generic Discount Method
static class DiscountManager
{
    public static void ApplyDiscount<T>(T product, double percentage) where T : Product<ProductCategory>
    {
        product.Price -= product.Price * (percentage / 100);
        Console.WriteLine($"Discount of {percentage}% applied to {product.Name}. New Price: ${product.Price:F2}");
    }
}

// Step 5: Test the Implementation
class Program
{
    static void Main()
    {
        // Creating categories
        BookCategory bookCategory = new BookCategory();
        ClothingCategory clothingCategory = new ClothingCategory();

        // Creating product catalog
        Catalog<Product<BookCategory>> bookCatalog = new Catalog<Product<BookCategory>>();
        Catalog<Product<ClothingCategory>> clothingCatalog = new Catalog<Product<ClothingCategory>>();

        // Adding products
        var book = new Product<BookCategory>(1, "C# Programming", 500, bookCategory);
        var shirt = new Product<ClothingCategory>(2, "Casual Shirt", 800, clothingCategory);

        bookCatalog.AddProduct(book);
        clothingCatalog.AddProduct(shirt);

        // Display products
        bookCatalog.DisplayProducts();
        clothingCatalog.DisplayProducts();

        // Apply discount
        DiscountManager.ApplyDiscount(book, 10);
        DiscountManager.ApplyDiscount(shirt, 15);

        // Display updated prices
        bookCatalog.DisplayProducts();
        clothingCatalog.DisplayProducts();
    }
}
